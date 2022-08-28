using MVCBasics.ViewModels;
using MVCBasics.Data;

namespace MVCBasics.Models
{
    public static class PeopleModel
    {
        public static List<Person> List()
        {
            return PeopleData.List;
        }


        public static List<Person> Search(string keyword)
        {
            return PeopleData.List.FindAll(person => ContainsKeyword(person, keyword));
        }


        public static List<Person> GetPerson(int id)
        {
            List<Person> list = new();

            var person = PeopleData.List.Find(person => person.ID == id);

            if (person != null)
            {
                list.Add(person);
            }

            return list;
        }


        public static void CreatePerson(CreatePersonViewModel person)
        {
            int newID = PeopleData.GenerateNewID();
            Person newPerson = new(person.Name, person.Phone, person.City, newID);
            PeopleData.List.Add(newPerson);
        }


        public static bool DeletePerson(int id)
        {
            var person = PeopleData.List.FirstOrDefault(person => person.ID == id);
            bool success = false;

            if (person != null)
            {
                success = PeopleData.List.Remove(person);
            }

            return success;
        }


        private static bool ContainsKeyword(Person person, string keyword)
        {
            return HasName(person, keyword) || HasPhonenumber(person, keyword) || LivesInCity(person, keyword);
        }


        private static bool HasName(Person person, string name)
        {
            return person.Name.ToLower().Contains(name.ToLower());
        }


        private static bool HasPhonenumber(Person person, string phonenumber)
        {
            return person.Phone.ToLower().Contains(phonenumber.ToLower());
        }


        private static bool LivesInCity(Person person, string city)
        {
            return person.City.ToLower().Contains(city.ToLower());
        }
    }
}
