using MVCBasics.Models;

namespace MVCBasics.Data
{
    public static class PeopleData
    {
        public static List<Person> List { get; set; } = new List<Person>()
        {
            new Person("Thor Odinson", "0123 456789", "New Asgard", 1),
            new Person("Erik Selvig", "1234 567890", "Stockholm", 2),
            new Person("Darcy Lewis", "2345 678901", "New York", 3),
            new Person("Jane Foster", "3456 789012", "New York", 4),
            new Person("Loki Odinson", "4567 890123", "Valhalla", 5),
        };

        private static int IDCounter = 5;

        public static int GenerateNewID()
        {
            IDCounter++;
            return IDCounter;
        }
    }
}
