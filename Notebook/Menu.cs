using System;

namespace Notebook
{
    public static class Menu
    {
        // Main menu
        // to navigate
        // through application

        
        private static void PrintCommand(string command)
        {
            // Highlight first
            // symbol to 
            // make hint for user

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(command[0]);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(command.Substring(1));
        }

        public static void ShowMenu()
        {
            // Available application commands

            Console.Write("Press: ");

            PrintCommand("Print"); // Highlight P
            Console.Write(", ");

            PrintCommand("Add"); // Highlight A
            Console.Write(", ");

            PrintCommand("Remove"); // Highlight R
            Console.Write(", ");

            PrintCommand("Order"); // Highlight O
            Console.WriteLine(", ");

            PrintCommand("Escape"); // Highlight E
            Console.Write(", ");

            PrintCommand("Name Search"); // Highlight N
            Console.Write(", ");

            PrintCommand("Telephone number Search"); // Highlight T
            Console.Write(", ");

            Console.Write("S");
            PrintCommand("urname Search"); // Highlight u
            Console.WriteLine();
        }
    }
}
