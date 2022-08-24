namespace MVCBasics.ViewModels
{
    public class Person
    {
        public Person(string name, string phone, string city)
        {
            Name = name;
            Phone = phone;
            City = city;
        }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
    }
}
