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
1. Enqueue a consumer.
2. Proceed an amount of consumer from the queue to the shop.
3. Print the amount of consumers in queue.");
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
                        Console.WriteLine($"Could not enqueue the consumer: {exception.Message}");
                    }
                    break;
                case ShopCommand.ProceedConsumers:
                    Console.WriteLine("Please enter a number: ");
                    var proceededConsumers = shop.ProceedConsumers(ReadNumber());
                    Console.WriteLine($"{proceededConsumers} consumers were proceeded to store.");
                    break;
                case ShopCommand.Print:
                    Console.WriteLine($"There are {shop.QueuedConsumers.Length} consumers in queue.");
                    break;
            }
        }

        private static Consumer ReadConsumer()
        {
            Consumer consumer = new Consumer();
            Console.WriteLine("Is the consumer masked?(Y/N)");
            consumer.Masked = ReadBool();
            Console.WriteLine("Is the consumer in quarantine?(Y/N)");
            consumer.Quarantined = ReadBool();
            Console.WriteLine("What's the consumer's body temperature (C)?");
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
