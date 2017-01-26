﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections.Generic;
using CSVLib;

namespace CSVTestProject
{
    [TestClass]
    public class UnitTestSortFirstNameAndLastNameData
    {
        [TestMethod]
        public void TestSortFirstnameAndLastName()
        {
            FileInfo testFile = new FileInfo(@"..\..\testDataCSV.csv");

            List<ClientData> data = new List<ClientData>();
            data.AddRange(CSVLib.CSVLib.GetData(testFile));

            foreach (var item in CSVLib.CSVLib.SortFirstAndLastNames(data))
            {
                switch (item.Item1)
                {
                    case "Brown" :
                        Assert.AreEqual(item.Item2, 2, string.Format(" Brown' Count should have been 2 instead it was {0}",item.Item2));
                        break;
                    case "Clive" :
                        Assert.AreEqual(item.Item2, 2, string.Format(" Clive' Count should have been 2 instead it was {0}", item.Item2));
                        break;
                    case "Graham" :
                        Assert.AreEqual(item.Item2, 2, string.Format(" Graham' Count should have been 2 instead it was {0}", item.Item2));
                        break;
                    case "Howe" :
                        Assert.AreEqual(item.Item2, 2, string.Format(" Howe' Count should have been 2 instead it was {0}", item.Item2));
                        break;
                    case "James" :
                        Assert.AreEqual(item.Item2, 2, string.Format(" James' Count should have been 2 instead it was {0}", item.Item2));
                        break;
                    case "Owen" :
                        Assert.AreEqual(item.Item2, 2, string.Format(" Owen' Count should have been 2 instead it was {0}", item.Item2));
                        break;
                    case "Smith" :
                        Assert.AreEqual(item.Item2, 2, string.Format(" Smith' Count should have been 2 instead it was {0}", item.Item2));
                        break;
                    case "Jimmy" :
                        Assert.AreEqual(item.Item2, 1, string.Format(" Jimmy' Count should have been 1 instead it was {0}", item.Item2));
                        break;
                    case "John" :
                        Assert.AreEqual(item.Item2, 1, string.Format(" John' Count should have been 1 instead it was {0}", item.Item2));
                        break;
                    default:
                        throw new InvalidDataException(string.Format("Test data in test file({0}) has extra data ({1})", testFile.FullName, item.Item1));
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Null parameter object was allowed.")]
        public void TestNullParametersForData()
        {
            CSVLib.CSVLib.SortFirstAndLastNames(null);
        }

        [TestMethod]
        public void TestEmptyParametersForData()
        {
            var list = new List<Tuple<string, int>>(CSVLib.CSVLib.SortFirstAndLastNames(new List<ClientData>()));
            Assert.AreEqual(list.Count, 0);
        }
    }
}