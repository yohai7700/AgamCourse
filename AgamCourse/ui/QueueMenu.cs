using System;
using AgamCourse.ui;
using AgamCourse.bl;

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
        static readonly string[] _options = new string[] {
            "Enqueue a costumer",
            "Proceed an amount of costumers from the queue to the shop",
            "Print the costumers in queue"
        };

        public QueueMenu(Shop shop) : base(_options)
        {
            this._shop = shop;
        }

        public override void OnOptionSelection(int option)
        {
            ShopCommand command = (ShopCommand)option;
            switch (command)
            {
                case ShopCommand.Enqueue:
                    RunEnqueueDialog();
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

        private void RunEnqueueDialog()
        {
            try
            {
                _shop.Enqueue(ReadConsumer());
            }
            catch (UnmaskedPersonException)
            {
                Console.WriteLine("Can't insert an unmasked person to the Queue.");
            }
            catch (QuarantinedPersonException)
            {
                Console.WriteLine("Can't insert a quarantined person to the Queue.");

            }
            catch (HighBodyTemperatureException)
            {
                Console.WriteLine($"Cant insert a person with a body temperature higher than {CovidCriteria.MaxBodyTemperature}C");

            }
        }

        private static Costumer ReadConsumer()
        {
            Console.WriteLine("What's the costumer's name?");
            string name = Console.ReadLine();
            var costumer = new Costumer(name);
            CovidSurvery.Update(costumer);
            return costumer;
        }
    }
}
