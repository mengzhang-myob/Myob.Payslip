using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Payslip.Domain
{
    public class PayDetails
    {
        private static List<TaxBracket> _taxBrackets = new List<TaxBracket>
        {
            new (0, 18200, 0, 0),
            new (18200, 37000, 0, 0.19),
            new (37000, 87000, 3572, 0.325),
            new (87000, 180000, 19822, 0.37),
            new (180000, null, 54232, 0.45),
        };

        //This function is just an experiment
        
        /*
        public IEnumerable<double?> findRange (double annualSalary)
        {
            return
                from taxBracket in _taxBrackets
                where annualSalary <= taxBracket.Maximum && annualSalary >= taxBracket.Minimum
                select taxBracket.Basic + (taxBracket.Maximum - annualSalary) * taxBracket.Rate;
        }
        */
        

        public int calcIncomeTax(double annualSalary)
        {
            var targetBracket = _taxBrackets.SingleOrDefault(b => annualSalary <= b.Maximum && annualSalary > b.Minimum);
            return (int) Math.Ceiling(
                    (targetBracket.Basic + (annualSalary - targetBracket.Minimum) * targetBracket.Rate)/12);
        }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string FullName => FirstName + " " + SurName;
        public string PayStartDate { get; set; }
        public string PayEndDate { get; set; }

        public string PayPeriod => PayStartDate + " - " + PayEndDate;
        public double AnnualSalary { get; set; }

        public int IncomeTax { get; set; }
        public int GrossIncome => (int) Math.Floor(AnnualSalary / 12);
        public int NetIncome => GrossIncome - IncomeTax;
        public int Super => (int) Math.Floor(GrossIncome * (SuperRate / 100));
        public double SuperRate { get; set; }
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