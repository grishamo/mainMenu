using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    class MenuItem : IMenuItem
    {
        #region Members 
        private string m_itemTitle;
        private List<MenuItem> m_submenu = new List<MenuItem>();
        #endregion Members

        #region Props
        public List<MenuItem> Submenu
        {
            get { return m_submenu; }
            set { m_submenu = value; }
        }
        public string Title
        {
            get { return m_itemTitle; }
            set { m_itemTitle = value; }
        }
        #endregion Props

        #region Constructors
        public MenuItem(string i_ItemName)
        {
            m_itemTitle = i_ItemName;
        }
        #endregion Constructors

        #region Methods
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
