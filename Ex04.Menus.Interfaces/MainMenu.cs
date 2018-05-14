using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    ///<summary>
    ///Main Menu with delegates implementation.
    ///</summary>
    public class MainMenu
    {
        #region Members
        private List<MenuItem> m_Menu = new List<MenuItem>();
        private List<MenuItem> m_AllMenuItems = new List<MenuItem>();
        #endregion Members

        #region Constructors
        public MainMenu(){}
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Build Menu Item Path and add action.
        /// <param name="i_MenuItemPath">
        /// Path of the menu action.
        /// all string that sepereted by comma will be build as a submenu.
        ///     e.g.: "About, info"
        /// </param>
        /// <param name="i_MenuAction">
        /// Action of the menu item
        /// </param>
        /// </summary>
        public void AddMenuItem(string i_MenuItemPath, Action i_MenuAction)
        {
            try
            {
                List<string> parsedMenuItemPath = parseToArray(i_MenuItemPath);
                MenuItem menuItem = buildMenuItemPath(parsedMenuItemPath);
                menuItem.MenuAction = i_MenuAction;
            }
            catch(Exception ex)
            {
                throw new Exception("Unable to build menu item");
            }
        }

        public void Select(string i_userInput)
        {
            foreach (MenuItem menuItem in m_AllMenuItems)
            {
                if (menuItem.Title == i_userInput)
                {
                    menuItem.Click();
                }
            }
        }

        public void Draw()
        {
            string outputString = "";
            foreach(var MenuItem in m_Menu)
            {
                outputString += string.Format("[{0}] ", MenuItem.Title);
            }

            Console.WriteLine(outputString);
        }

        private MenuItem buildMenuItemPath(List<string> i_MenuItemPathArray)
        {
            List<MenuItem> submenu = m_Menu;
            MenuItem nextItemMenu = null;

            foreach(string itemName in i_MenuItemPathArray)
            {
                nextItemMenu = new MenuItem(itemName);

                if(submenu.Contains(nextItemMenu))
                {
                    submenu = submenu[submenu.IndexOf(nextItemMenu)].Submenu;
                }
                else
                {
                    submenu.Add(nextItemMenu);
                    m_AllMenuItems.Add(nextItemMenu);
                    submenu = nextItemMenu.Submenu;
                }
            }
            
            return nextItemMenu;
        } 

        private List<string> parseToArray(string i_MenuItemPath)
        {
            List<string> menuPathArray = i_MenuItemPath.Split(',').ToList();

            //remove first char of string if its 'space'
            for(int i = 0; i < menuPathArray.Count; i++)
            {
                if (Char.IsWhiteSpace(menuPathArray[i], 0))
                {
                    menuPathArray[i] = menuPathArray[i].Substring(1);
                }
            }

            return menuPathArray;
        }
        #endregion Methods
    }
}
