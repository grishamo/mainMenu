using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Ex04.Menus;

namespace Ex04.Menu.Test
{
    class Program
    {
        static void Main()
        {
            string userInput;
            Menus.Delegates.MainMenu mainMenu = new Menus.Delegates.MainMenu();

            mainMenu.AddMenuItem("Delegates", buildDelegatesMenu);
            mainMenu.AddMenuItem("Interface", buildInterfaceMenu);
            mainMenu.AddMenuItem("Exit", null);

            do
            {
                Console.WriteLine("Choose Menu:");
                mainMenu.Draw();

                userInput = Console.ReadLine();
                mainMenu.Invoke(userInput);
            }
            while (userInput != "Exit");
            
        }
      
        static void buildDelegatesMenu(object obj)
        {
            Menus.Delegates.MainMenu mainMenuDelegates = new Menus.Delegates.MainMenu();
            string userInput;

            mainMenuDelegates.AddMenuItem("Show Date/Time, Show Date", MouseEvents.ShowDate);
            mainMenuDelegates.AddMenuItem("Show Date/Time, Show Time", MouseEvents.ShowTime);
            mainMenuDelegates.AddMenuItem("Version and Capitals, Count Capitals", MouseEvents.CountCapitals);
            mainMenuDelegates.AddMenuItem("Version and Capitals, Show Version", MouseEvents.ShowVersion);
            mainMenuDelegates.AddMenuItem("Exit", null);
            mainMenuDelegates.Draw();
            
            do
            {
                userInput = Console.ReadLine();
                mainMenuDelegates.Invoke(userInput);
            }
            while (userInput != "Exit");
            
        }

        static void buildInterfaceMenu(object obj)
        {
            Menus.Interfaces.MainMenu mainMenuInterface = new Menus.Interfaces.MainMenu();
            string userInput;

            mainMenuInterface.AddMenuItem("Show Date/Time, Show Date");
            mainMenuInterface.AddMenuItem("Show Date/Time, Show Time");
            mainMenuInterface.AddMenuItem("Version and Capitals, Count Capitals");
            mainMenuInterface.AddMenuItem("Version and Capitals, Show Version");
            mainMenuInterface.AddMenuItem("Exit");
            mainMenuInterface.Draw();

            do
            {
                userInput = Console.ReadLine();
                mainMenuInterface.Invoke(userInput);
                MouseEvents.Invoke(userInput);
            }
            while (userInput != "Exit");

        }

    }

    class MouseEvents
    {
        public static void Invoke(string i_methodName)
        {
            string noSpacesMethodName = i_methodName.Replace(" ", "");
            MethodInfo method = typeof(MouseEvents).GetMethod(noSpacesMethodName);
            if (method != null)
            {
               method.Invoke(method, new object[] { null });
            }
        }

        public static void ShowDate(object obj)
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(date.ToShortDateString());
        }

        public static void ShowTime(object obj)
        {
            DateTime date = DateTime.Now;
            Console.WriteLine(date.ToShortTimeString());
        }

        public static void ShowVersion(object obj)
        {
            Console.WriteLine("Version: 18.2.4.0");
        }

        public static void CountCapitals(object obj)
        {
            Console.WriteLine("Please enter word:");
            string userInput = Console.ReadLine();
            int count = 0;

            foreach (char letter in userInput)
            {
                if (Char.IsUpper(letter))
                {
                    count++;
                }
            }

            Console.WriteLine("Nuber of uppercase letters: " + count);
        }
    }
}
