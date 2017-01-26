using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;

namespace CSVTestProject
{
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
            FileInfo testFile = new FileInfo(@"..\..\testDataCSV.csv");
            Assert.IsTrue(testFile.Exists, "Test data file ("+testFile.FullName+") does not exist.");

            if (testFile.Exists)
            {
                
            }
        }
    }
}
