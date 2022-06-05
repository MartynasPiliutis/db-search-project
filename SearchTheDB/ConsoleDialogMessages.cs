using System;

namespace SearchTheDB
{
    public class ConsoleDialogMessages
    {
        public string InputRequestMessage()
        {
            string userInput = "";
            Console.WriteLine("Press [1] to enter a SQL query");
            Console.WriteLine("Press [2] to enter values");
            string inputSelection = Convert.ToString(Console.ReadKey().KeyChar);
            Console.Clear();
            Console.WriteLine($"Your input is {inputSelection}");
            if (inputSelection == "1")
            {
                Console.WriteLine("Please enter your SQL query:");
                userInput = Convert.ToString(Console.ReadLine());
                userInput = userInput + " FOR JSON AUTO";
                return userInput;
            }
            else
            {
                if (inputSelection == "2")
                {
                    Console.WriteLine("Please enter name of the column:");
                    string column = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Please enter value for the column:");
                    string value = Convert.ToString(Console.ReadLine());
                    userInput = $"SELECT * FROM [DocLogixTaskDB].[dbo].[AuditingReport] WHERE [{column}] LIKE '%{value}%' FOR JSON AUTO";
                }
                else
                {
                    Console.WriteLine("Wrong input. Bye!!!");
                    Environment.Exit(0);
                }
            }
            return userInput;
        }

        public void SqlExceptionErrorMessage()
        {
            Console.WriteLine("Unable to complete your request.");
            Console.WriteLine("Column you are searching does not exist. Please review your query.");
            Console.WriteLine("The program will terminate...");
        }
    }
}
