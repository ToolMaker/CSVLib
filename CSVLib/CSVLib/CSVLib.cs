﻿namespace CSVLib
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// CSVLib is used to manage a static CS structure for out Assement
    /// NOTE: I'm not fond of comments as I believe code should be readable and not heavily commented,
    ///         If code is heavily commented then it created maintenace work.
    ///         However if there is a documentation requirment then the subject is debatble
    /// </summary>
    public class CSVLib
    {
        public static async Task<IEnumerable<ClientData>> GetData(FileInfo file)
        {
            List<ClientData> data = new List<ClientData>();

            if (file.Exists)
            {
                using (StreamReader reader = new StreamReader(file.OpenRead()))
                {
                    try
                    {
                        //Skip header row, dont read if EOF feed
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            string dataLine = await reader.ReadLineAsync();
                            string[] dataRow = dataLine.Split(',');
                            data.Add(new ClientData()
                            {
                                FirstName = dataRow[0],
                                LastName = dataRow[1],
                                Address = dataRow[2],
                                PhoneNumber = dataRow[3]
                            });
                        }
                    }
                    catch (ArgumentOutOfRangeException aore)
                    {
                        throw new InvalidDataException("Input Data format exception", aore);
                    }
                    catch (IndexOutOfRangeException iore)
                    {
                        throw new InvalidDataException("Input Data format exception", iore);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException(string.Format("File {0} not found !", file.FullName));
            }

            return data;
        }

        public static void SplitData(DirectoryInfo directory, List<Tuple<string, int>> firstAndLastNamesSorted, List<Tuple<string, string>> streetNamesSorted)
        {
            var firstAndLastNameSlitTask = WriteFirstAndLastNamesAsync(firstAndLastNamesSorted, directory.FullName + @"\FirstAndLastNames.txt");

            var streetNamesSlitTask = WriteStreetNamesAsync(streetNamesSorted, directory.FullName + @"\StreetNames.txt");

            firstAndLastNameSlitTask.Wait();
            streetNamesSlitTask.Wait();
        }

        private static async Task<bool> WriteStreetNamesAsync(List<Tuple<string, string>> streetNamesSorted, string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            using (StreamWriter writer = new StreamWriter(file.OpenWrite()))
            {
                StringBuilder writeString = new StringBuilder();
                streetNamesSorted.ForEach((item) => {
                    writeString.AppendFormat("{0} {1}{2}", item.Item1, item.Item2,Environment.NewLine);
                });

                await writer.WriteAsync(writeString.ToString());
            }
            return true;
        }

        private static async Task<bool> WriteFirstAndLastNamesAsync(List<Tuple<string, int>> firstAndLastNamesSorted, string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (file.Exists)
            {
                file.Delete();
            }

            using (StreamWriter writer = new StreamWriter(file.OpenWrite()))
            {
                StringBuilder writeString = new StringBuilder();
                firstAndLastNamesSorted.ForEach((item) => {
                    writeString.AppendFormat("{0}, {1}{2}", item.Item1, item.Item2, Environment.NewLine);
                });

                await writer.WriteAsync(writeString.ToString());
            }
            return true;
        }

        public static List<Tuple<string, int>> SortFirstAndLastNamesSorted(List<ClientData> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("ClientData Object supplied was NULL");
            }

            if (data.Count == 0)
            {
                return new List<Tuple<string, int>>();
            }

            List<string> firstNamesAndLastNames = new List<string>(data.Select(x => x.FirstName));
            firstNamesAndLastNames.AddRange(data.Select(x => x.LastName));

            var sorting = firstNamesAndLastNames.Distinct()
                .Select(x => new Tuple<string, int>(x, firstNamesAndLastNames.Where(c => c.Equals(x)).Count()))
                .OrderByDescending(o => o.Item2)
                .ThenBy(n => n.Item1)
                .ToList();

            return sorting;
        }

        public static List<Tuple<string, string>> SortStreetAddress(List<ClientData> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("ClientData Object supplied was NULL");
            }

            if (data.Count == 0)
            {
                return new List<Tuple<string, string>>();
            }

            return data.Select(x => new Tuple<string, string>(
                x.Address.Substring(0, x.Address.IndexOf(' ')),
                x.Address.Substring(x.Address.IndexOf(' ') + 1)))
                .OrderBy(y => y.Item2)
                .ToList();
        }
    }
}
