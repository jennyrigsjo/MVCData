using MVCBasics.ViewModels;
using MVCBasics.Data;

namespace MVCBasics.Models
{
    public static class PeopleModel
    {
        public static PeopleViewModel List()
        {
            PeopleViewModel viewModel = new()
            {
                List = PeopleData.List
            };

            return viewModel;
        }


        public static PeopleViewModel Search(string keyword)
        {
            PeopleViewModel viewModel = new()
            {
                Search = keyword,
                List = PeopleData.List.FindAll(person => ContainsKeyword(person, keyword))
            };

            return viewModel;
        }


        public static PeopleViewModel CreatePerson(CreatePersonViewModel person)
        {
            int newID = PeopleData.GenerateNewID();
            Person newPerson = new(person.Name, person.Phone, person.City, newID);

            PeopleData.List.Add(newPerson);

            PeopleViewModel viewModel = new()
            {
                List = PeopleData.List
            };

            return viewModel;
        }


        public static PeopleViewModel DeletePerson(int id)
        {
            //var person = PeopleData.List.FirstOrDefault(person => person.Name.ToLower() == name.ToLower());
            var person = PeopleData.List.FirstOrDefault(person => person.ID == id);

            if (person != null)
            {
                PeopleData.List.Remove(person);
            }

            PeopleViewModel viewModel = new()
            {
                List = PeopleData.List
            };

            return viewModel;
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
