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

            }
        }
    }
}
