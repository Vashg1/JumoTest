using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Jumo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Process_Click(object sender, EventArgs e)
        {
            Hashtable hashtable = new Hashtable();
            int NumberOfLoans = 0;
            bool PassedFirstline = false;
            bool Append = false;
            string[] Columns;
            int Date = 0;
            int Network = 0;
            int Product = 0;
            int Amount = 0;

            if (File.Exists(@"c:\temp\Loan.csv"))
            {
                string[] FileLines = File.ReadAllLines(@"c:\temp\Loan.csv");

                NumberOfLoans = FileLines.Count() - 1;//Write number of records in file - 1 to give you total number of loans
                foreach (string line in FileLines)
                {
                    if (PassedFirstline == false) //To handle the Header Row in the file
                    {
                        PassedFirstline = true;
                        Columns = Regex.Split(line, line.Substring(0, 11));
                        string[] ColumnNameInd = line.Split(',');

                        //Finding the indexes of the ColumnNames
                        for (int i = 0; i < (ColumnNameInd.Length); i++)
                        {
                            if (ColumnNameInd[i].ToString() == "Date")
                            {
                                Date = i;
                            }

                            if (ColumnNameInd[i].ToString() == "Network")
                            {
                                Network = i;
                            }

                            if (ColumnNameInd[i].ToString() == "Product")
                            {
                                Product = i;
                            }

                            if (ColumnNameInd[i].ToString() == "Amount")
                            {
                                Amount = i;
                            }
                        }
                        continue;
                    }
                    // To split the first 11 chars in the string and use them as key values                
                    string[] match = Regex.Split(line, line.Substring(0, 11));
                    string[] rows = line.Split(',');
                    DateTime date = DateTime.Parse(rows[Date]);

                    string htkey = rows[Network] + ',' + date.ToString("MMMM") + ',' + rows[Product];

                    if (hashtable.ContainsKey(htkey))
                    {
                        hashtable[htkey] = Convert.ToDouble(hashtable[htkey].ToString()) + Convert.ToDouble(rows[Amount]);
                    }
                    else
                    {

                        hashtable.Add(htkey, rows[Amount]);
                    }
                }

             

                if (File.Exists(@"c:\temp\Output.csv"))
                {
                    DialogResult res = MessageBox.Show("File exists, do you want to append to file", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (res == DialogResult.Yes)
                    {
                        MessageBox.Show("Thank you, File is being Appended");
                        Append = true;

                    }
                    if (res == DialogResult.No)
                    {
                        MessageBox.Show("Thank you, Please make a copy of OutPut.csv and process again");
                    }
                }

                if ((Append) || (!File.Exists(@"c:\temp\Output.csv")))
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"c:\temp\Output.csv", true))
                    {
                        file.WriteLine("Number of loans received in file: " + NumberOfLoans);
                        file.WriteLine("List of loans below");
                        foreach (String key in hashtable.Keys)
                        {
                            string NewVal = hashtable[key].ToString();
                            file.Write(key);
                            file.WriteLine(NewVal);
                        }
                        MessageBox.Show("Thank you, File is saved!");

                    }
            }
            else
            {
                MessageBox.Show("No file Loan file to process!");
            }
        }
    }
}
