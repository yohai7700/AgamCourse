using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    enum ShopCommand
    {
        Enqueue = 1,
        ProceedConsumers,
        Print
    }

    class ShopPrompt
    {
        Shop shop;
        public ShopPrompt(Shop shop)
        {
            this.shop = shop;
        }

        public void Run()
        {
            while (true) ExecuteCommand(ReadCommand());
            
        }

        private static ShopCommand ReadCommand()
        {
            Console.WriteLine(@"
Hello, please choose one of the following options (enter the option's number):
1. Enqueue a costumer.
2. Proceed an amount of costumers from the queue to the shop.
3. Print the costumers in queue.");
            int command;
            do
            {
                command = ReadNumber();
            } while (!(1 <= command && command <= 3));
            return (ShopCommand)command;
        }

        private void ExecuteCommand(ShopCommand command)
        {
            switch(command)
            {
                case ShopCommand.Enqueue:
                    try
                    {
                        shop.Enqueue(ReadConsumer());
                    } catch (Exception exception)
                    {
                        Console.WriteLine($"Could not enqueue the costumer: {exception.Message}");
                    }
                    break;
                case ShopCommand.ProceedConsumers:
                    Console.WriteLine("Please enter a number: ");
                    var proceededConsumers = shop.ProceedCostumers(ReadNumber());
                    Console.WriteLine($"{proceededConsumers} costumers were proceeded to store.");
                    break;
                case ShopCommand.Print:
                    Console.WriteLine($"There are {shop.QueuedCostumers.Length} costumers in the queue.");
                    foreach (var consumer in shop.QueuedCostumers)
                    {
                        Console.WriteLine($"* {consumer.Name}");
                    }
                    break;
            }
        }

        private static Costumer ReadConsumer()
        {
            Console.WriteLine("What's the costumer's name?");
            string name = Console.ReadLine();
            Costumer consumer = new Costumer(name);
            Console.WriteLine("Is the costumer masked?(Y/N)");
            consumer.Masked = ReadBool();
            Console.WriteLine("Is the costumer in quarantine?(Y/N)");
            consumer.Quarantined = ReadBool();
            Console.WriteLine("What's the costumer's body temperature (C)?");
            consumer.BodyTemperature = ReadFloat();
            return consumer;
        }

        private static int ReadNumber()
        {
            int number;
            bool isValid;
            do
            {
                isValid = Int32.TryParse(Console.ReadLine(), out number);
            } while (!isValid);
            return number;
        }

        private static float ReadFloat()
        {
            float number;
            bool isValid;
            do
            {
                isValid = float.TryParse(Console.ReadLine(), out number);
            } while (!isValid);
            return number;
        }

        private static bool ReadBool()
        {
            string answer;
            do
            {
                answer = Console.ReadLine();
            } while (!("Y".Equals(answer) || "N".Equals(answer)));
            return "Y".Equals(answer);
        }
    }
}
