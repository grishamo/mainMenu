using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    interface IMenuItem
    {
        List<MenuItem> Submenu
        {
            get;
            set;
        }
        string Title
        {
            get;
            set;
        }
    }
}
