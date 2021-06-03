using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using Myob.Payslip.Domain;

namespace Myob.Payslip.Console

{
    public class UserImport
    {
        public List<PayDetails> payDetailsList = new List<PayDetails>();
        private string resultToCSV;
        public void readImportPath(string path)
        {
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    var payDetails = new PayDetails();
                    payDetails.FirstName = fields[0];
                    payDetails.SurName = fields[1];
                    payDetails.AnnualSalary = Convert.ToDouble(fields[2]);
                    payDetails.SuperRate = Convert.ToDouble(fields[3]);
                    payDetails.PayStartDate = fields[4];
                    payDetails.PayEndDate = fields[5];
                    payDetails.calcIncomeTax();
                    payDetailsList.Add(payDetails);
                }
            }
        }

        public void exportPayDetails()
        {
            var csv = new StringBuilder();
            /*System.Console.WriteLine("There are " + payDetailsList.Count + " elements there");*/
            foreach (var payDetails in payDetailsList)
            {
                resultToCSV = string.Join(",", payDetailsToArray(payDetails));
                csv.AppendLine(resultToCSV);
            }

            File.WriteAllText("/Users/meng.zhang/Downloads/test.csv", csv.ToString());
            System.Console.WriteLine("Result exported successfully");
        }

        public List<string> payDetailsToArray(PayDetails payDetails)
        {
            List<string> result = new List<string> {
                payDetails.FullName, 
                payDetails.PayPeriod, 
                payDetails.GrossIncome.ToString(),
                payDetails.IncomeTax.ToString(),
                payDetails.NetIncome.ToString(),
                payDetails.Super.ToString()
            };
            return result;
        }

        public bool tryParsePath(string csvPath)
        {
            return true;
        }
    }

}