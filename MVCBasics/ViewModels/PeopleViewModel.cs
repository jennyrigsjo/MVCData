namespace MVCBasics.ViewModels
{
    public class PeopleViewModel
    {
        public List<Person> List { get; set; } = new List<Person>();

        public string Search { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public int StatusCode { get; set; } = 0;
    }
}
