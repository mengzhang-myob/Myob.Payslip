using System;
using System.Collections.Generic;

namespace Myob.Payslip.Domain
{
    public class PayDetails
    {
        //Q regarding property: What to do with the calculation in the setter (no arguments allowed in the setter, how to parse taxRate/taxThreshold in)?
        //My answers: Create independent function for calculation (not sure) 
        private static List<double> taxRate = new List<double> {0.19, 0.325, 0.37, 0.45};
        private static List<int> taxThreshold = new List<int> {18200, 37000, 87000, 180000};
        private static List<int> taxBracket = new List<int> {0, 3572, 19822, 54232};
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string FullName => FirstName + " " + SurName;
        public string PayStartDate { get; set; }
        public string PayEndDate { get; set; }

        public string PayPeriod => PayStartDate + " - " + PayEndDate;
        public double AnnualSalary { get; set; }

        public int IncomeTax { get; set; }

        public int GrossIncome { get; set; }
        public int NetIncome { get; set; }
        public int Super { get; set; }
        public double SuperRate { get; set; }

        public int CalcGrossIncome(double annualSalary)
        {
            return (int) Math.Floor(annualSalary / 12);
        }

        public int CalcIncomeTax(double annualSalary)
        {
            if (annualSalary <= taxThreshold[0])
            {
                // When income <= 18200
                return taxBracket[0];
            }
            else if (annualSalary <= taxThreshold[1])
            {
                // When 18201 < income <= 37000
                return (int) Math.Ceiling(((annualSalary - taxThreshold[0]) * taxRate[0]) / 12);
            }
            else if (taxThreshold[1] < annualSalary && annualSalary <= taxThreshold[2])
            {
                // When 37000 < income <= 87000
                return (int) Math.Ceiling(((annualSalary - taxThreshold[1]) * taxRate[1] + taxBracket[1]) / 12);
            }
            else if (taxThreshold[2] < annualSalary && annualSalary <= taxThreshold[3])
            {
                // When 87000 < income <= 180000
                return (int) Math.Ceiling(
                    ((annualSalary - taxThreshold[2]) * taxRate[2] + taxBracket[1] + taxBracket[2]) / 12);
            }
            else if (taxThreshold[3] < annualSalary)
            {
                // When 180000 < income
                return (int) Math.Ceiling(((annualSalary - taxThreshold[3]) * taxRate[3] + taxBracket[1] +
                                           taxBracket[2] + taxBracket[3]) / 12);
            }

            return 0;
        }

        public int CalcNetIncome()
        {
            return GrossIncome - IncomeTax;
        }

        public int CalcSuper(double superRate)
        {
            return (int) Math.Floor(GrossIncome * (superRate / 100));
        }

        public void PrintPayDetails()
        {
            Console.WriteLine(
                "Your payslip has been generated:\n" +
                "Name: " + FullName + "\n" +
                "Pay Period: " + PayPeriod + "\n" +
                "Gross Income: " + GrossIncome + "\n" +
                "Income Tax: " + IncomeTax + "\n" +
                "Net Income: " + NetIncome + "\n" +
                "Super: " + Super + "\n" + "\n" +
                "Thank you for using MYOB!"
            );
        }

        public bool TrySetAnnualSalary(string salary, PayDetails payDetails)
        {
            var isValid = Double.TryParse(salary, out double result);
            if (isValid)
            {
                payDetails.AnnualSalary = result;
            }
            return isValid;
            //TODO assign the value to annual salary property
        }

        public bool TrySetSuperRate(string superRate, PayDetails payDetails)
        {
            var isValid = Double.TryParse(superRate, out double result);
            if (isValid)
            {
                payDetails.SuperRate = result;
            }

            return isValid;
        }
    }
}