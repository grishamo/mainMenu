using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interface
{
    class MenuItem : IMenuItem
    {
        #region Members
        Action m_itemAction;
        private List<MenuItem> m_submenu = new List<MenuItem>(); 
        private string m_itemTitle;
        #endregion Members

        #region Props
        public string Title
        {
            get { return m_itemTitle; }
            set { m_itemTitle = value; }
        }

        public Action MenuAction
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
        public void FireAction()
        {
            m_itemAction();
        }
        #endregion Methods
    }
}
