using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interface
{
    ///<summary>
    ///Main Manu with interface implementation
    ///</summary>
    public class MainMenu
    {
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();

        #region Constructors
        public MainMenu()
        {

        }
        #endregion Constructors

        #region Methods
        public void AddMenuItem(string i_MenuItemName, Action i_MenuAction)
        {
            MenuItem newMenuItem = new MenuItem(i_MenuItemName);
            newMenuItem.MenuAction = i_MenuAction;
            r_MenuItems.Add(newMenuItem);
        }

        public void Invoke(string i_userInput)
        {
            foreach(var menuItem in r_MenuItems)
            {
                if(menuItem.Title == i_userInput)
                {
                    menuItem.FireAction();
                }
            }
        }

        public void Draw()
        {
            foreach(var MenuItem in r_MenuItems)
            {
                Console.WriteLine("{0} ", MenuItem.Title);
            }
        }
        #endregion Methods
    }
}
