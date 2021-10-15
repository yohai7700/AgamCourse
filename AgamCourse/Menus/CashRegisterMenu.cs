using System;
using System.Collections.Generic;
using System.Linq;

namespace AgamCourse.Menus
{
    enum Option
    {
        AssignCashRegister = 1,
        PrintShifts
    }
    class CashRegisterMenu : InternalMenu
    {
        static readonly string[] _options = new string[] { "Assign to available cash register", "Print all shifts" };

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
                case Option.PrintShifts:
                    PrintAllShifts();
                    break;
            }
        }

        private void AssignCashRegister()
        {
            var availableRegister = _shop.FindAvailableCashRegister();
            if (availableRegister == null)
            {
                Console.WriteLine("No cash register is available at the moment, please try later.");
                return;
            }
            var costumer = RenderCostumersDialog();
            if (costumer == null)
            {
                Console.WriteLine("No costumer is in the shop right now, can't assign to cash register.");
                return;
            }
            Console.WriteLine($"Assigned to Cash Register: {costumer.Name}");
        }

        void PrintAllShifts()
        {
            var shifts = _shop.CashRegisterShifts;
            Console.WriteLine($"There have been {shifts} shifts");
            foreach (var shift in shifts)
            {
                string formattedEndDate = shift.Ended ? shift.EndDate.ToString() : "Present";
                Console.WriteLine($"* {shift.Employee.Name}: {shift.StartDate} - {formattedEndDate}");
            }
        }

        private Costumer RenderCostumersDialog()
        {
            var costumers = _shop.Costumers;
            if (costumers.Length == 0) return null;

            var costumerIndex = new Infra.OptionsDialog(costumers.Select(costumer => costumer.Name).ToArray()).Render();
            return costumers[costumerIndex];
        }
    }
}
