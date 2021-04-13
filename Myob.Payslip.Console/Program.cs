using Myob.Payslip.Domain;

namespace Myob.Payslip.Console
{
    class Program
    {
        // string inputType;
        // string inputValue;
        static void Main(string[] args)
        {
            System.Console.WriteLine("This program calculate the income tax, gross income, net income and super based on positive values");
            PayDetails payDetails = new PayDetails();
            UserInput userInput = new UserInput();
            userInput.InputName(payDetails);
            userInput.InputAnnualSalary(payDetails);
            userInput.InputSuperRate(payDetails);
            userInput.InputDates(payDetails);
            payDetails.PrintPayDetails();
            //TODO: set print as UserInput()
        }
    }
}
