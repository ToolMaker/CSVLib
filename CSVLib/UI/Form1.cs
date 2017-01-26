using CSVLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            labelFilesCreated.Text = string.Empty;
            labelDirectories.Text = string.Empty;

            if (openCSVFileDialog.ShowDialog() == DialogResult.OK
                && openCSVFileDialog.CheckFileExists)
            {
                textBoxFileName.Text = openCSVFileDialog.FileName;
                FileInfo csvFile = new FileInfo(openCSVFileDialog.FileName);

                IEnumerable<ClientData> dataCollection = CSVLib.CSVLib.GetData(csvFile).Result;

                List<ClientData> data = new List<ClientData>(dataCollection);

                var firstAndLastNamesSorted = CSVLib.CSVLib.SortFirstAndLastNamesSorted(data);
                var streetNamesSorted = CSVLib.CSVLib.SortStreetAddress(data);

                CSVLib.CSVLib.SplitData(csvFile.Directory,firstAndLastNamesSorted,streetNamesSorted);

                labelFilesCreated.Text = "Files Created, check following Directory for FirstAndLastNames.txt and StreetNames.txt:";

                labelDirectories.Text = csvFile.Directory.FullName;
            }
        }
    }
}
