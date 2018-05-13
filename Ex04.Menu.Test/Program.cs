using System;
using System.Collections.Generic;
using System.Text;
using Ex04.Menus.Interface;

namespace Ex04.Menu.Test
{
    class Program
    {
        static void Main()
        {
            string userInput;
            MainMenu mainMenu = new MainMenu();
            mainMenu.AddMenuItem("Show Date", ShowDate);

            mainMenu.Draw();
            userInput = getUserInput();

            mainMenu.Invoke(userInput);

            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }

        static string getUserInput()
        {
            Console.WriteLine("Select item");
            return Console.ReadLine();
        }

        static void ShowDate()
        {
            DateTime date = new DateTime();
            Console.WriteLine(date.ToShortDateString());
        }
    }
}
