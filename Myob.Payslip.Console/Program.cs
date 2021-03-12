using System;
using System.Text.RegularExpressions;
using Myob.Payslip.Domain;

namespace Payslip
{
    class Program
    {
        // string inputType;
        // string inputValue;
        static void Main(string[] args)
        {
            PayDetails payDetails = new PayDetails();
            UserInput("name", payDetails);
            UserInput("annualSalary", payDetails);
            UserInput("superRate", payDetails);
            UserInput("pDate", payDetails);
            UserInput("print", payDetails);
        }
        static void UserInput (string inputType, PayDetails payDetails){
            Regex regexSalary = new Regex(@"^-?[0-9][0-9\.]+$"); //Regex to tolerate decimal point
            // Regex regexSuper = new Regex("^([1-9]\d?|100)$");
            // Regex regexDate = new Regex(@"^\d$");
            if (inputType == "name"){
                try {
                    Console.WriteLine("Please input your name:");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Please input your surname:");
                    string surName = Console.ReadLine();
                    payDetails.Name = firstName + " " + surName; //Consider to decouple
                }
                catch(Exception e) {
                    Console.WriteLine("The name input is invalid" + "\n" + e.Message);
                }

            }
            else if (inputType == "annualSalary"){
                    Console.WriteLine("Please enter your annual salary:");
                    try {
                        string inputSalary = Console.ReadLine();
                        while (regexSalary.IsMatch(inputSalary) == false){
                            Console.WriteLine("Wrong format, the annual salary should be numbers only, please re-enter your annual salary:");
                            inputSalary = Console.ReadLine();
                        }
                        double inputValue = Convert.ToDouble(inputSalary);
                        payDetails.GrossIncome = payDetails.CalcGrossIncome(inputValue);
                        payDetails.IncomeTax = payDetails.CalcIncomeTax(inputValue);
                        payDetails.NetIncome = payDetails.CalcNetIncome();
                    }
                    catch (Exception e) {
                        throw e;
                }
            }
            else if (inputType == "superRate"){
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
            else if (inputType == "pDate"){
                Console.WriteLine("Please enter your payment start date:");
                string pStartDate = Console.ReadLine();
                Console.WriteLine("Please enter your payment end date:");
                string pEndDate = Console.ReadLine();
                payDetails.PayPeriod = pStartDate + "-" + pEndDate;
            }
            else if (inputType == "print") {
                payDetails.PrintPayDetails();
            }
        }
    }
}
