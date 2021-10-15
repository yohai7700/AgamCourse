using System.Collections.Generic;
using System.Linq;

namespace AgamCourse.bl
{
    public interface CovidInfectionChecker
    {
        public Person[] AllPossibleInfectedPeople { get; }
        public Person[] FindInfectedPeople(Person infected);
    }
    public class ShopCovidInfectionChecker : CovidInfectionChecker
    {
        Shop _shop;

        public ShopCovidInfectionChecker(Shop shop)
        {
            _shop = shop;
        }

        public Person[] AllPossibleInfectedPeople
        {
            get
            {
                var peopleSet = new HashSet<Person>();
                foreach (var shift in _shop.CashRegisterShifts)
                {
                    peopleSet.Add(shift.Employee);
                    foreach (var purchase in shift.Purchases)
                    {
                        peopleSet.Add(purchase.Costumer);
                    }
                }
                return setToArray(peopleSet);
            }
        }
        public Person[] FindInfectedPeople(Person infected)
        {
            var infectedSet = new HashSet<Person>();
            foreach (var shift in _shop.CashRegisterShifts)
            {
                if (shift.Purchases.Any(purchase => purchase.Costumer.Equals(infected)))
                {
                    infectedSet.Add(shift.Employee);
                    foreach (var purchase in shift.Purchases) infectedSet.Add(purchase.Costumer);
                }
            }
            infectedSet.Remove(infected);
            return setToArray(infectedSet);
        }

        private static Person[] setToArray(HashSet<Person> set)
        {
            var people = new Person[set.Count];
            set.CopyTo(people);
            return people;
        }
    }
}
