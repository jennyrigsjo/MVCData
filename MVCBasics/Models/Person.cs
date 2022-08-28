namespace MVCBasics.Models
{
    public class Person
    {
        public Person(string name, string phone, string city, int id)
        {
            Name = name;
            Phone = phone;
            City = city;
            ID = id;
        }

        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public int ID { get; set; } = 0;
    }
}
