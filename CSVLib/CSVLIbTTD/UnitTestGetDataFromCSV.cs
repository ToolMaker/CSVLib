namespace CSVTestProject
{
    using CSVLib;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// This Unit Test will test the input data from pre-setup csv files
    /// for followingUnit tests to base their tests on.
    /// </summary>
    [TestClass]
    public class UnitTestGetDataFromCSV
    {
        /// <summary>
        /// This test method confirms all test data is in order for the following tests to validate according to this data structure.
        /// Data structor layout for test:
        ///     FirstName	LastName	Address	            PhoneNumber
        /// 1    Jimmy       Smith	    102 Long Lane	    29384857
        /// 2    Clive       Owen	    65 Ambling Way	    31214788
        /// 3    James       Brown	    82 Stewart St	    32114566
        /// 4    Graham      Howe	    12 Howard St	    8766556
        /// 5    John        Howe	    78 Short Lane	    29384857
        /// 6    Clive       Smith	    49 Sutherland St	31214788
        /// 7    James       Owen	    8 Crimson Rd	    32114566
        /// 8    Graham      Brown	    94 Roland St	    8766556
        /// </summary>
        
        [TestMethod]
        public void ReadCSVData()
        {
            FileInfo testFile = new FileInfo(@"..\..\Data\testDataCSV.csv");
            Assert.IsTrue(testFile.Exists, "Test data file ("+testFile.FullName+") does not exist.");

            if (testFile.Exists)
            {
                IEnumerable<ClientData> dataCollection = CSVLib.GetData(testFile).Result;

                List<ClientData> data = new List<ClientData>(dataCollection);

                if (!(StringAssert.Equals(data[0].FirstName, "Jimmy")
                    && StringAssert.Equals(data[0].LastName, "Smith")
                    && StringAssert.Equals(data[0].Address, "102 Long Lane")
                    && StringAssert.Equals(data[0].PhoneNumber, "29384857")))
                {
                    throw new AssertFailedException("Test data invalid at row 1");
                }

                if (!(StringAssert.Equals(data[1].FirstName, "Clive")
                    && StringAssert.Equals(data[1].LastName, "Owen")
                    && StringAssert.Equals(data[1].Address, "65 Ambling Way")
                    && StringAssert.Equals(data[1].PhoneNumber, "31214788")))
                {
                    throw new AssertFailedException("Test data invalid at row 2");
                }

                if ((!StringAssert.Equals(data[2].FirstName, "James")
                    && StringAssert.Equals(data[2].LastName, "Brown")
                    && StringAssert.Equals(data[2].Address, "82 Stewart St")
                    && StringAssert.Equals(data[2].PhoneNumber, "32114566")))
                {
                    throw new AssertFailedException("Test data invalid at row 3");
                }

                if ((!StringAssert.Equals(data[3].FirstName, "Graham")
                    && StringAssert.Equals(data[3].LastName, "Howe")
                    && StringAssert.Equals(data[3].Address, "12 Howard St")
                    && StringAssert.Equals(data[3].PhoneNumber, "8766556")))
                {
                    throw new AssertFailedException("Test data invalid at row 4");
                }

                if ((!StringAssert.Equals(data[4].FirstName, "John")
                    && StringAssert.Equals(data[4].LastName, "Howe")
                    && StringAssert.Equals(data[4].Address, "78 Short Lane")
                    && StringAssert.Equals(data[4].PhoneNumber, "29384857")))
                {
                    throw new AssertFailedException("Test data invalid at row 5");
                }

                if ((!StringAssert.Equals(data[5].FirstName, "Clive")
                    && StringAssert.Equals(data[5].LastName, "Smith")
                    && StringAssert.Equals(data[5].Address, "49 Sutherland St")
                    && StringAssert.Equals(data[5].PhoneNumber, "31214788")))
                {
                    throw new AssertFailedException("Test data invalid at row 6");
                }

                if ((!StringAssert.Equals(data[6].FirstName, "James")
                    && StringAssert.Equals(data[6].LastName, "Owen")
                    && StringAssert.Equals(data[6].Address, "8 Crimson Rd")
                    && StringAssert.Equals(data[6].PhoneNumber, "32114566")))
                {
                    throw new AssertFailedException("Test data invalid at row 7");
                }

                if ((!StringAssert.Equals(data[7].FirstName, "Graham")
                    && StringAssert.Equals(data[7].LastName, "Brown")
                    && StringAssert.Equals(data[7].Address, "94 Roland St")
                    && StringAssert.Equals(data[7].Address, "8766556")))
                {
                    throw new AssertFailedException("Test data invalid at row 8");
                }
            }
        }

    }
}
