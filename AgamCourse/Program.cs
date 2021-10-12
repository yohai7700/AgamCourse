using System;

namespace AgamCourse
{
    class Program
    {
        static void Main(string[] args) 
        {
            Shop shop = new Shop();
            MainMenu menu = new MainMenu(shop);
            menu.Run();
        }
    }
}
