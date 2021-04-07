using System;
using Myob.Payslip.Domain;

namespace Myob.Payslip.Console
{
    public class UserInput
    {
        // Regex regexSalary = new Regex(@"^-?[0-9][0-9\.]+$"); //Regex to tolerate decimal point
        public void InputName (PayDetails payDetails)
        {
            try {
                System.Console.WriteLine("Please input your name:");
                payDetails.FirstName = System.Console.ReadLine();
                System.Console.WriteLine("Please input your surname:");
                payDetails.SurName = System.Console.ReadLine();
            }
            catch(Exception e) {
                System.Console.WriteLine("The name input is invalid" + "\n" + e.Message);
            }
        }

        public void InputAnnualSalary (PayDetails payDetails)
        {
            try
            {
                System.Console.WriteLine("Please enter your annual salary:");
                string inputSalary;
                var promptUser = false;
                do
                {
                    inputSalary = System.Console.ReadLine();
                    promptUser = !payDetails.TrySetAnnualSalary(inputSalary, payDetails);
                    if (promptUser)
                    {
                        System.Console.WriteLine("Wrong format, the annual salary should be numbers only, please re-enter your annual salary:");
                    }
                } while (promptUser);
                /*  while (regexSalary.IsMatch(inputSalary) == false){
                    Console.WriteLine("Wrong format, the annual salary should be numbers only, please re-enter your annual salary:");
                    inputSalary = Console.ReadLine(); 
                }*/
                double inputValue = Convert.ToDouble(inputSalary);
                payDetails.IncomeTax = payDetails.calcIncomeTax(inputValue);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void InputSuperRate (PayDetails payDetails)
        {
            System.Console.WriteLine("Please enter your super rate:");
            string inputSupreRate;
            var promptUser = false;
            try {
                do
                {
                    inputSupreRate = System.Console.ReadLine();
                    promptUser = !payDetails.TrySetSuperRate(inputSupreRate, payDetails);
                    if (promptUser)
                    {
                        System.Console.WriteLine("Wrong format, the super rate should be numbers only, please re-enter your super rate:");
                    }
                } while (promptUser);
                // while (regexSalary.IsMatch(inputRate) == false){
                //     Console.WriteLine("Wrong format, the super rate should be numbers only, please re-enter your super rate:");
                //     inputRate = Console.ReadLine();
                // }
                // payDetails.Super = payDetails.CalcSuper(inputValue);
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void InputDates(PayDetails payDetails)
        {
            System.Console.WriteLine("Please enter your payment start date:");
            payDetails.PayStartDate = System.Console.ReadLine();
            System.Console.WriteLine("Please enter your payment end date:");
            payDetails.PayEndDate = System.Console.ReadLine();
        }
    }
}