using System;

namespace AgamCourse
{
    class Program
    {
        static void Main(string[] args) 
        {
            Shop shop = new Shop();
            ShopMenu prompt = new ShopMenu(shop);
            prompt.Run();
        }
    }
}
