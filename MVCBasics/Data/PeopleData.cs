using MVCBasics.ViewModels;

namespace MVCBasics.Data
{
    public static class PeopleData
    {
        public static List<Person> List { get; set; } = new List<Person>()
        {
            new Person("Thor Odinson", "0123 456789", "New Asgard"),
            new Person("Erik Selvig", "1234 567890", "Stockholm"),
            new Person("Darcy Lewis", "2345 678901", "New York"),
            new Person("Jane Foster", "3456 789012", "New York"),
            new Person("Loki Odinson", "4567 890123", "Valhalla"),
        };
    }
}
