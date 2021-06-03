using System;
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
            System.Console.WriteLine
                (
                "Please select how do you want to enter data by press number:\n" +
                 "[1] I want to enter the data manually via the console.\n" +
                 "[2] I want to import the file.\n" +
                 "NOTE: If you select [2], you need to enter the absolute path of your file, only .csv file will be accepted\n"
                );
            string userInputKey = System.Console.ReadLine();
            if (userInputKey == "1")
            {
                PayDetails payDetails = new PayDetails();
                UserInput userInput = new UserInput();
                userInput.InputName(payDetails);
                userInput.InputAnnualSalary(payDetails);
                userInput.InputSuperRate(payDetails);
                userInput.InputDates(payDetails);
                payDetails.PrintPayDetails();
            }
            else if (userInputKey == "2")
            {
                System.Console.WriteLine("Please paste your path here:");
                UserImport userImport = new UserImport();
                string importPath = System.Console.ReadLine();
                userImport.readImportPath(importPath);
                /*System.Console.WriteLine("\nSorry, you've just selected a feature that is still in development, you are recommended to terminate the program.");
                Environment.Exit(0);*/
                userImport.exportPayDetails();
            }
            else
            {
                System.Console.WriteLine("\nYour selection is invalid");
                Environment.Exit(0);
            }
                

            //TODO: set print as UserInput()
        }

        /*
         static bool TryParseUserSelection(string key)
        {
            if (key == "1" || key == "2")
            {
                return true;
            }
            return false;
        }
        */
    }
}
