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
            if (openCSVFileDialog.ShowDialog() == DialogResult.OK
                && openCSVFileDialog.CheckFileExists)
            {
                FileInfo csvFile = new FileInfo(openCSVFileDialog.FileName);

                List<ClientData> data = new List<ClientData>(CSVLib.CSVLib.GetData(csvFile));

                var firstAndLastNamesSorted = CSVLib.CSVLib.SortFirstAndLastNamesSorted(data);
                var streetNamesSorted = CSVLib.CSVLib.SortStreetAddress(data);

                //Back to TDD
            }
        }
    }
}
