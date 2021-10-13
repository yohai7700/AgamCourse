using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse.Menus
{
    enum Option
    {
        AssignCashRegister = 1
    }
    class CashRegisterMenu : InternalMenu
    {
        static readonly string[] _options = new string[] { "Assign to available cash register" };

        Shop _shop;
        public CashRegisterMenu(Shop shop) : base(_options) 
        {
            _shop = shop;
        }

        public override void OnOptionSelection(int option)
        {
            switch ((Option)option)
            {
                case Option.AssignCashRegister:
                    AssignCashRegister();
                    break;
            }
        }

        private void AssignCashRegister()
        {
            var availableRegister = _shop.FindAvailableCashRegister();
            if(availableRegister == null)
            {
                Console.WriteLine("No cash register is available at the moment, please try later.");
                return;
            }
            availableRegister.Costumer = new Costumer("Name");
            Console.WriteLine("Assigned to Cash Register");
        }
    }
}
