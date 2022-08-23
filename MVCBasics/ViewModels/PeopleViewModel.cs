using MVCBasics.Models;

namespace MVCBasics.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> People { get; set; } = new List<Person>()
        {
            new Person("Thor Odinson", "0123 456789", "New Asgard"),
            new Person("Erik Selvig", "1234 567890", "Stockholm"),
            new Person("Darcy Lewis", "2345 678901", "New York"),
            new Person("Jane Foster", "3456 789012", "New York"),
        };

        public string Search { get; set; } = string.Empty;
    }
}
