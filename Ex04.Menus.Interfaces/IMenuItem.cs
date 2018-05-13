using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interface
{
    public interface IMenuItem
    {
        string Title
        {
            get;
            set;
        }
        void FireAction();
    }
}
