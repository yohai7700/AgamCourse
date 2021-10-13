using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse.Menus
{
    class CashRegisterMenu : InternalMenu
    {
        static readonly string[] _options = new string[] { };
        public CashRegisterMenu() : base(_options) { }

        public override void OnOptionSelection(int option)
        {
            throw new NotImplementedException();
        }
    }
}
