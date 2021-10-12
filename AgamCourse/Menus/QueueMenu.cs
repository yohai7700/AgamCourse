using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    enum ShopCommand
    {
        Enqueue = 1,
        ProceedConsumers,
        Print,
        ChooseRegister
    }

    class QueueMenu : InternalMenu
    {
        Shop _shop;
        static readonly string[] Options = new string[] { 
            "Enqueue a costumer", 
            "Proceed an amount of costumers from the queue to the shop", 
            "Print the costumers in queue" 
        };

        public QueueMenu(Shop shop) : base(Options)
        {
            this._shop = shop;
        }

        public override void OnOptionSelection(int option)
        {
            ShopCommand command = (ShopCommand)option;
            switch (command)
            {
                case ShopCommand.Enqueue:
                    try
                    {
                        _shop.Enqueue(ReadConsumer());
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine($"Could not enqueue the costumer: {exception.Message}");
                    }
                    break;
                case ShopCommand.ProceedConsumers:
                    Console.WriteLine("Please enter a number: ");
                    var proceededConsumers = _shop.ProceedCostumers(ReadNumber());
                    Console.WriteLine($"{proceededConsumers} costumers were proceeded to store.");
                    break;
                case ShopCommand.Print:
                    Console.WriteLine($"There are {_shop.QueuedCostumers.Length} costumers in the queue.");
                    foreach (var consumer in _shop.QueuedCostumers)
                    {
                        Console.WriteLine($"* {consumer.Name}");
                    }
                    break;
                case ShopCommand.ChooseRegister:
                    var register = _shop.FindAvailableCashRegister();
                    if (register == null)
                    {
                        Console.WriteLine("No available register was found");
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
    }
}
