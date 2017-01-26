namespace CSVTestProject
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;
    using CSVLib;
    using System.Collections.Generic;

    [TestClass]
    public class UnitTestSortStreetNames
    {
        [TestMethod]
        public void TestSortStreetName()
        {
            FileInfo testFile = new FileInfo(@"..\..\Data\testDataCSV.csv");

            IEnumerable<ClientData> dataCollection = CSVLib.GetData(testFile).Result;

            List<ClientData> data = new List<ClientData>(dataCollection);

            int counter = 0;
            foreach (var item in CSVLib.SortStreetAddress(data))
            {
                switch (counter++)
                {
                    case 0 :
                        Assert.AreEqual(item.Item1, "65", string.Format(" Street Number should have been {0}", item.Item1));
                        Assert.AreEqual(item.Item2, "Ambling Way", string.Format("Street Name shoulf have been {0}", item.Item2));
                        break;
                    case 1:
                        Assert.AreEqual(item.Item1, "8", string.Format(" Street Number should have been {0}", item.Item1));
                        Assert.AreEqual(item.Item2, "Crimson Rd", string.Format("Street Name shoulf have been {0}", item.Item2));
                        break;
                    case 2:
                        Assert.AreEqual(item.Item1, "12", string.Format(" Street Number should have been {0}", item.Item1));
                        Assert.AreEqual(item.Item2, "Howard St", string.Format("Street Name shoulf have been {0}", item.Item2));
                        break;
                    case 3:
                        Assert.AreEqual(item.Item1, "102", string.Format(" Street Number should have been {0}", item.Item1));
                        Assert.AreEqual(item.Item2, "Long Lane", string.Format("Street Name shoulf have been {0}", item.Item2));
                        break;
                    case 4:
                        Assert.AreEqual(item.Item1, "94", string.Format(" Street Number should have been {0}", item.Item1));
                        Assert.AreEqual(item.Item2, "Roland St", string.Format("Street Name shoulf have been {0}", item.Item2));
                        break;
                    case 5:
                        Assert.AreEqual(item.Item1, "78", string.Format(" Street Number should have been {0}", item.Item1));
                        Assert.AreEqual(item.Item2, "Short Lane", string.Format("Street Name shoulf have been {0}", item.Item2));
                        break;
                    case 6:
                        Assert.AreEqual(item.Item1, "82", string.Format(" Street Number should have been {0}", item.Item1));
                        Assert.AreEqual(item.Item2, "Stewart St", string.Format("Street Name shoulf have been {0}", item.Item2));
                        break;
                    case 7:
                        Assert.AreEqual(item.Item1, "49", string.Format(" Street Number should have been {0}", item.Item1));
                        Assert.AreEqual(item.Item2, "Sutherland St", string.Format("Street Name shoulf have been {0}", item.Item2));
                        break;
                }
            }
        }

        [TestMethod]
        public void TestEmptyParametersForData()
        {
            var list = new List<Tuple<string, string>>(CSVLib.SortStreetAddress(new List<ClientData>()));

            Assert.AreEqual(list.Count, 0);
        }
    }
}
