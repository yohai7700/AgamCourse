using AgamCourse.bl;
using AgamCourse.ui;

namespace AgamCourse
{
    enum Option
    {
        QueueManagement = 1,
        CashRegister,
        CovidInfection,
        EmployeeManagement,
        Exit
    }
    class MainMenu : Menu
    {
        static readonly string[] _options = new string[]
        {
            "Queue Management",
            "Cash Register Management",
            "Covid Infection",
            "Employee Management",
            "Exit"
        };

        QueueMenu _queueMenu;
        CashRegisterMenu _cashRegisterMenu;
        CovidInfectionMenu _covidInfectionMenu;
        EmployeeManagementMenu _employeeManagementMenu;


        public MainMenu(Shop shop) : base(_options, false)
        {
            _queueMenu = new QueueMenu(shop);
            _cashRegisterMenu = new CashRegisterMenu(shop);
            _covidInfectionMenu = new CovidInfectionMenu(new ShopCovidInfectionChecker(shop));
            _employeeManagementMenu = new EmployeeManagementMenu(shop.EmployeeManager);
        }

        public override void OnOptionSelection(int option)
        {
            switch ((Option)option)
            {
                case Option.QueueManagement:
                    _queueMenu.Run();
                    break;
                case Option.CashRegister:
                    _cashRegisterMenu.Run();
                    break;
                case Option.CovidInfection:
                    _covidInfectionMenu.Run();
                    break;
                case Option.EmployeeManagement:
                    _employeeManagementMenu.Run();
                    break;
                case Option.Exit:
                    Finish();
                    break;
            }
        }
    }
}
