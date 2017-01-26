using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVLib
{
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
    }
}
