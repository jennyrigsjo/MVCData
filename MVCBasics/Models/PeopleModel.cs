using MVCBasics.ViewModels;

namespace MVCBasics.Models
{
    public static class PeopleModel
    {
        public static PeopleViewModel Search(string keyword)
        {
            PeopleViewModel viewModel = new()
            {
                Search = keyword
            };
            
            List<Person> result = viewModel.List.FindAll(person => ContainsKeyword(person, keyword));
            viewModel.List = result;

            return viewModel;
        }

        public static PeopleViewModel CreatePerson(CreatePersonViewModel person)
        {
            Person newPerson = new(person.Name, person.Phone, person.City);

            PeopleViewModel viewModel = new();

            viewModel.List.Add(newPerson);

            return viewModel;
        }

        public static PeopleViewModel DeletePerson(string name)
        {
            PeopleViewModel viewModel = new();

            var person = viewModel.List.FirstOrDefault(person => person.Name.ToLower() == name.ToLower());

            if (person != null)
            {
                viewModel.List.Remove(person);
            }

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
