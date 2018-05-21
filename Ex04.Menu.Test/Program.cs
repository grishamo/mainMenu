using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus;

namespace Ex04.Menu.Test
{
    class Program
    {
        static void Main()
        {
            string userInput;
            Menus.Delegates.MainMenu mainMenuDelegates = new Menus.Delegates.MainMenu();
            Menus.Interfaces.MainMenu mainMenuInterfaces = new Menus.Interfaces.MainMenu();

            mainMenuInterfaces.AddMenuItem("Show Date/Time, Show Date");
            mainMenuInterfaces.AddMenuItem("Show Date/Time, Show Time");
            mainMenuInterfaces.AddMenuItem("Version and Capitals, Count Capitals");
            mainMenuInterfaces.AddMenuItem("Version and Capitals, Show Version");
            mainMenuInterfaces.AddMenuItem("Exit");
            mainMenuInterfaces.Draw();


            mainMenuDelegates.AddMenuItem("Show Date/Time, Show Date", ShowDate);
            mainMenuDelegates.AddMenuItem("Show Date/Time, Show Time", ShowTime);
            mainMenuDelegates.AddMenuItem("Version and Capitals, Count Capitals", CountCapitals);
            mainMenuDelegates.AddMenuItem("Version and Capitals, Show Version", ShowVersion);
            mainMenuDelegates.AddMenuItem("Exit", null);
            mainMenuDelegates.Draw();

            do
            {
                userInput = Console.ReadLine();
                mainMenuDelegates.Invoke(userInput);
            }
            while (userInput != "Exit");
            

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }


        static void ShowDate(object obj)
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(date.ToShortDateString());
        }

        static void ShowTime(object obj)
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(date.ToShortTimeString());
        }

        static void ShowVersion(object obj)
        {
            Console.WriteLine("Version: 18.2.4.0");
        }

        static void CountCapitals(object obj)
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
