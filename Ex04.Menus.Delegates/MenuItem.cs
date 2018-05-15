using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Delegates
{
    class MenuItem
    {
        #region Members 
        Action<object> m_itemAction;
        private List<MenuItem> m_submenu = new List<MenuItem>(); 
        private string m_itemTitle;
        #endregion Members

        #region Props
        public string Title
        {
            get { return m_itemTitle; }
            set { m_itemTitle = value; }
        }
        public List<MenuItem> Submenu
        {
            get { return m_submenu; }
            set { m_submenu = value; }
        }
        public Action<object> MenuAction
        {
            get { return m_itemAction; }
            set { m_itemAction = value; }
        }
        #endregion Props

        #region Constructors
        public MenuItem(string i_ItemName)
        {
            m_itemTitle = i_ItemName;
        }
        #endregion Constructors

        #region Methods
        public void Click()
        {
            if(MenuAction != null)
            {
                m_itemAction(this);
            }

            if (Submenu.Count > 0)
            {
                DrawSubmenu();
            }
        }

        public void DrawSubmenu()
        {
            string outputString = "";
            foreach (var MenuItem in Submenu)
            {
                outputString += string.Format("[{0}] ", MenuItem.Title);
            }

            Console.WriteLine("\n" + Title);
            Console.WriteLine(outputString);
        }

        public override bool Equals(object obj)
        {
            return (obj as MenuItem).Title == Title;
        }

        public static bool operator ==(MenuItem i_obj1, MenuItem i_obj2)
        {
            return i_obj1.Title == i_obj2.Title;
        }

        public static bool operator !=(MenuItem i_obj1, MenuItem i_obj2)
        {
            return !(i_obj1 == i_obj2);
        }
        #endregion Methods
    }
}
