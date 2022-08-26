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


        public static PeopleViewModel GetPerson(int id = 0)
        {
            PeopleViewModel viewModel = new();
            var person = PeopleData.List.Find(person => person.ID == id);

            if (id == 0)
            {
                viewModel.Message = "Please provide an ID.";
                viewModel.StatusCode = 400;
            }

            else if (person == null)
            {
                viewModel.Message = $"Item with ID '{id}' does not exist.";
                viewModel.StatusCode = 400;
            }

            else
            {
                viewModel.Message = $"Successfully retrieved item with ID '{id}'.";
                viewModel.StatusCode = 200;
                viewModel.List.Add(person);
            }

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


        public static PeopleViewModel DeletePerson(int id = 0)
        {
            PeopleViewModel viewModel = new();
            var person = PeopleData.List.FirstOrDefault(person => person.ID == id);

            if (id == 0)
            {
                viewModel.List = PeopleData.List;
                viewModel.Message = "Please provide an ID.";
                viewModel.StatusCode = 400;
            }

            else if (person == null)
            {
                viewModel.List = PeopleData.List;
                viewModel.Message = $"Item with ID '{id}' could not be deleted because it does not exist.";
                viewModel.StatusCode = 400;
            }

            else
            {
                bool success = PeopleData.List.Remove(person);
                viewModel.List = PeopleData.List;
                viewModel.Message = success ? $"Item with ID '{id}' has been successfully deleted." : $"Item with ID '{id}' exists but it could not be deleted.";
                viewModel.StatusCode = success ? 200 : 400;
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
