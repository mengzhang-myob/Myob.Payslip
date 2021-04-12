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
        

        public void calcIncomeTax()
        {
            var targetBracket = _taxBrackets.SingleOrDefault(b => AnnualSalary <= b.Maximum && AnnualSalary > b.Minimum);
            if (AnnualSalary > 180000)
            {
                targetBracket = _taxBrackets.SingleOrDefault(b => b.Minimum == 180000);
            }

            if (AnnualSalary == 0)
            {
                targetBracket = new TaxBracket(0, 0, 0, 0);

            }
            //TODO improve the LINQ statement when annual salary is greater than 180000.
            IncomeTax = (int) Math.Ceiling(
                    (targetBracket.Basic + (AnnualSalary - targetBracket.Minimum) * targetBracket.Rate)/12);
        }
        
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string FullName => FirstName + " " + SurName;
        public string PayStartDate { get; set; }
        public string PayEndDate { get; set; }

        public string PayPeriod => PayStartDate + " - " + PayEndDate;
        public double AnnualSalary { get; set; }
        public bool AnnualSalaryWasNegative { get; set; }

        public int IncomeTax { get; set; } //TODO maybe call calcIncomeTax in  the setter with arrows
        public int GrossIncome => (int) Math.Floor(AnnualSalary / 12); //=> means every time it's being accessed, it will recalculate (
        public int NetIncome => GrossIncome - IncomeTax;
        public int Super => (int) Math.Floor(GrossIncome * (SuperRate / 100));
        public double SuperRate { get; set; }
        public bool SuperRateWasNegative { get; set; }
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

        public bool TrySetAnnualSalary(string salary)
        /* My thoughts here re handling negative input (also applies to TrySetSuperRate):
                Option 1: Create PayDetails property called AnnualSalaryNegative, default value false.
                Option 2: No creation for new property, return an array of 2 items within this method: 
                    item 1: isValid (format check), item 2: isNegative (negative check).
                Option 1 is easier to understand, however it creates additional property for single-use (maybe?).
                Option 2 is more efficient, but may affect readability.
        */
        {
            var isValid = Double.TryParse(salary, out double result);
            //TODO handle negative value, consider test case with negative value and a false output -> DONE
            if (isValid)
            {
                if (result < 0)
                {
                    AnnualSalary = result * -1;
                    AnnualSalaryWasNegative = true;
                }
                else
                {
                    AnnualSalary = result;
                    AnnualSalaryWasNegative = false;
                }
            }
            return isValid;
            //TODO assign the value to annual salary property, instead of parsing object as parameter -> DONE
        }

        public bool TrySetSuperRate(string superRate)
        {
            var isValid = Double.TryParse(superRate, out double result);
            //TODO handle negative value 
            if (isValid)
            {
                if (result < 0)
                {
                    SuperRate = result * -1;
                    SuperRateWasNegative = true;
                }
                else
                {
                    SuperRate = result;
                    SuperRateWasNegative = false;
                }
            }

            return isValid;
        }
    }
}