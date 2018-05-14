using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Delegates;

namespace Ex04.Menu.Test
{
    class Program
    {
        static void Main()
        {
            string userInput;
            MainMenu mainMenu = new MainMenu();
            mainMenu.AddMenuItem("Show Date/Time, Show Date", ShowDate);
            mainMenu.AddMenuItem("Show Date/Time, Show Time", ShowTime);
            mainMenu.AddMenuItem("Version and Capitals, Count Capitals", CountCapitals);
            mainMenu.AddMenuItem("Version and Capitals, Show Version", ShowVersion);
            mainMenu.AddMenuItem("Exit", null);
            mainMenu.Draw();

            do
            {
                userInput = Console.ReadLine();
                mainMenu.Select(userInput);
            }
            while (userInput != "Exit");
            

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }


        static void ShowDate()
        {
            DateTime date = new DateTime();
            Console.WriteLine(date.ToShortDateString());
        }

        static void ShowTime()
        {
            DateTime date = new DateTime();
            Console.WriteLine(date.ToShortTimeString());
        }

        static void ShowVersion()
        {
            Console.WriteLine("Version: 18.2.4.0");
        }

        static void CountCapitals()
        {
            Console.WriteLine("Please enter word:");
            string userInput = Console.ReadLine();
            int count = 0;

            foreach(char letter in userInput)
            {
                if(Char.IsUpper(letter))
                {
                    count++;
                }
            }

            Console.WriteLine("Nuber of uppercase letters: " + count);
        }
    }
}
