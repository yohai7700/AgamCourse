using AgamCourse.Menus;

namespace AgamCourse
{
    enum Option
    {
        QueueManagement = 1,
        CashRegisterMenu = 2,
    }
    class MainMenu : Menu
    {
        static readonly string[] _options = new string[]
        {
            "Queue Management",
            "Cash Register Menu"
        };

        QueueMenu _queueMenu;
        CashRegisterMenu _cashRegisterMenu;


        public MainMenu(Shop shop) : base(_options, false)
        {
            _queueMenu = new QueueMenu(shop);
            _cashRegisterMenu = new CashRegisterMenu(shop);
        }

        public override void OnOptionSelection(int option)
        {
            switch((Option)option)
            {
                case Option.QueueManagement:
                    _queueMenu.Run();
                    break;
                case Option.CashRegisterMenu:
                    _cashRegisterMenu.Run();
                    break;  
            }
        }
    }
}
