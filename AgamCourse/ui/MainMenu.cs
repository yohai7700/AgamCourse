using AgamCourse.Menus;
using AgamCourse.bl;

namespace AgamCourse
{
    enum Option
    {
        QueueManagement = 1,
        CashRegister,
        CovidInfection,
    }
    class MainMenu : Menu
    {
        static readonly string[] _options = new string[]
        {
            "Queue Management",
            "Cash Register Management",
            "Covid Infection"
        };

        QueueMenu _queueMenu;
        CashRegisterMenu _cashRegisterMenu;
        CovidInfectionMenu _covidInfectionMenu;


        public MainMenu(Shop shop) : base(_options, false)
        {
            _queueMenu = new QueueMenu(shop);
            _cashRegisterMenu = new CashRegisterMenu(shop);
            _covidInfectionMenu = new CovidInfectionMenu(new ShopCovidInfectionChecker(shop));
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
            }
        }
    }
}
