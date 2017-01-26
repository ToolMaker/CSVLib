namespace CSVLib
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// CSVLib is used to manage a static CS structure for out Assement
    /// NOTE: I'm not fond of comments as I believe code should be readable and not heavily commented,
    ///         If code is heavily commented then it created maintenace work.
    ///         However if there is a documentation requirment then the subject is debatble
    /// </summary>
    public class CSVLib
    {
        public static IEnumerable<ClientData> GetData(FileInfo file)
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
                            string[] dataRow = reader.ReadLine().Split(',');
                            data.Add(new ClientData()
                            {
                                FirstName = dataRow[0],
                                LastName = dataRow[1],
                                Address = dataRow[2],
                                PhoneNumber = dataRow[3]
                            });
                        }

                        if(data.Count == 0)
                        {
                            //Empty file
                            throw new InvalidDataException("Input Data format exception");
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

        public static IEnumerable<Tuple<string, int>> SortFirstAndLastNamesSorted(List<ClientData> data)
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
