namespace CSVLIbTTD
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using CSVLib;
    using System.Collections.Generic;

    [TestClass]
    public class UnitTestSplitter
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileInfo testFile = new FileInfo(@"..\..\Data\testDataCSV.csv");
            Assert.IsTrue(testFile.Exists, "Test data file (" + testFile.FullName + ") does not exist.");

            if (testFile.Exists)
            {
                IEnumerable<ClientData> dataCollection = CSVLib.GetData(testFile).Result;

                List<ClientData> data = new List<ClientData>(dataCollection);

                var firstAndLastNamesSorted = CSVLib.SortFirstAndLastNamesSorted(data);

                var streetNamesSorted = CSVLib.SortStreetAddress(data);

                CSVLib.SplitData(testFile.Directory, firstAndLastNamesSorted, streetNamesSorted);

                FileInfo namesFile = new FileInfo(testFile.Directory+ @"\FirstAndLastNames.txt");
                Assert.IsTrue(namesFile.Exists, "FirstAndLastNames.txt should have been created");

                FileInfo streetNames = new FileInfo(testFile.Directory + @"\StreetNames.txt");
                Assert.IsTrue(namesFile.Exists, "StreetNames.txt should have been created");
            }
        }
    }
}
