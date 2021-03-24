using System;
using System.Text.RegularExpressions;

namespace Myob.Payslip.Domain
{
    public class UserInput
    {
        Regex regexSalary = new Regex(@"^-?[0-9][0-9\.]+$"); //Regex to tolerate decimal point
        public void InputName (PayDetails payDetails)
        {
            try {
                Console.WriteLine("Please input your name:");
                payDetails.FirstName = Console.ReadLine();
                Console.WriteLine("Please input your surname:");
                payDetails.SurName = Console.ReadLine();
            }
            catch(Exception e) {
                Console.WriteLine("The name input is invalid" + "\n" + e.Message);
            }
        }

        public void InputAnnualSalary (PayDetails payDetails)
        {
            try
            {
                Console.WriteLine("Please enter your annual salary:");
                string inputSalary;
                var promptUser = false;
                do
                {
                    inputSalary = Console.ReadLine();
                    promptUser = !payDetails.TrySetAnnualSalary(inputSalary, payDetails);
                    if (promptUser)
                    {
                        Console.WriteLine("Wrong format, the annual salary should be numbers only, please re-enter your annual salary:");
                    }
                } while (promptUser);
                /*  while (regexSalary.IsMatch(inputSalary) == false){
                    Console.WriteLine("Wrong format, the annual salary should be numbers only, please re-enter your annual salary:");
                    inputSalary = Console.ReadLine(); 
                }*/
                double inputValue = Convert.ToDouble(inputSalary);
                payDetails.GrossIncome = payDetails.CalcGrossIncome(inputValue);
                payDetails.IncomeTax = payDetails.CalcIncomeTax(inputValue);
                payDetails.NetIncome = payDetails.CalcNetIncome();
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void InputSuperRate (PayDetails payDetails)
        {
            Console.WriteLine("Please enter your super rate:");
            try {
                string inputRate = Console.ReadLine();
                while (regexSalary.IsMatch(inputRate) == false){
                    Console.WriteLine("Wrong format, the super rate should be numbers only, please re-enter your super rate:");
                    inputRate = Console.ReadLine();
                }
                double inputValue = Convert.ToDouble(inputRate);
                payDetails.Super = payDetails.CalcSuper(inputValue);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void InputDates(PayDetails payDetails)
        {
            Console.WriteLine("Please enter your payment start date:");
            payDetails.PayStartDate = Console.ReadLine();
            Console.WriteLine("Please enter your payment end date:");
            payDetails.PayEndDate = Console.ReadLine();
        }
    }
}