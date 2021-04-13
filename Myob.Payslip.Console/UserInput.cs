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
            try {
                System.Console.WriteLine("Please enter your annual salary:");
                string inputSalary;
                var promptUserFormat = false;
                do
                {
                    inputSalary = System.Console.ReadLine();
                    promptUserFormat = !payDetails.TrySetAnnualSalary(inputSalary);
                    if (promptUserFormat)
                    {
                        System.Console.WriteLine("Wrong format, the annual salary should be numbers only, please re-enter your annual salary:");
                    }
                    else
                    {
                        System.Console.WriteLine("You entered annual salary: " + payDetails.AnnualSalary);
                    }
                } while (promptUserFormat);
                /*  while (regexSalary.IsMatch(inputSalary) == false){
                    Console.WriteLine("Wrong format, the annual salary should be numbers only, please re-enter your annual salary:");
                    inputSalary = Console.ReadLine(); 
                }*/
                payDetails.calcIncomeTax();
            }
            catch (Exception e) {
                throw e;
            }
        }

        public void InputSuperRate (PayDetails payDetails)
        {
            try {
                System.Console.WriteLine("Please enter your super rate:");
                string inputSuperRate;
                var promptUserFormat = false;
                do
                {
                    inputSuperRate = System.Console.ReadLine();
                    promptUserFormat = !payDetails.TrySetSuperRate(inputSuperRate);
                    if (promptUserFormat)
                    {
                        System.Console.WriteLine("Wrong format, the super rate should be numbers only, please re-enter your super rate:");
                    }
                    else
                    {
                        System.Console.WriteLine("You entered super rate: " + payDetails.SuperRate);
                    }
                } while (promptUserFormat);
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