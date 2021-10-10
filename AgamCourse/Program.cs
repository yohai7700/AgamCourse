using System;

namespace AgamCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            ShopPrompt prompt = new ShopPrompt(shop);
            prompt.Run();
        }
    }
}
