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
            UserInput userInput = new UserInput();
            userInput.InputName(payDetails);
            userInput.InputAnnualSalary(payDetails);
            userInput.InputSuperRate(payDetails);
            userInput.InputDates(payDetails);
            payDetails.PrintPayDetails();
        }
    }
}
