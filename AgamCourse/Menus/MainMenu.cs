using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    class MainMenu : Menu
    {
        static readonly string[] Options = new string[]
        {
            "Queue Management",
        };

        QueueMenu _queueMenu;


        public MainMenu(Shop shop) : base(Options, false)
        {
            _queueMenu = new QueueMenu(shop);
        }

        public override void OnOptionSelection(int option)
        {
            switch(option)
            {
                case 1:
                    _queueMenu.Run();
                    break;      
            }
        }
    }
}
