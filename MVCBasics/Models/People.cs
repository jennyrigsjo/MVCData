using MVCBasics.ViewModels;

namespace MVCBasics.Models
{
    public static class People
    {
        public static PeopleViewModel Search(string keyword)
        {
            PeopleViewModel viewModel = new();
            viewModel.Search = keyword;
            
            List<Person> result = viewModel.People.FindAll(person => ContainsKeyword(person, keyword));
            viewModel.People = result;

            return viewModel;
        }

        private static bool ContainsKeyword(Person person, string keyword)
        {
            return person.Name.ToLower().Contains(keyword) || person.Phone.ToLower().Contains(keyword) || person.City.ToLower().Contains(keyword);
        }
    }
}
