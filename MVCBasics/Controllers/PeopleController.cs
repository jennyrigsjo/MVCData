using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel()
                {
                    List = PeopleModel.List()
                }
            };

            return View(viewModels);
        }


        [HttpPost]
        public IActionResult Search(string search)
        {
            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel()
                {
                    Search = search,
                    List = PeopleModel.Search(search)
                }
            };

            return View("Index", viewModels);
        }


        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel person)
        {
            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel(),
                CreatePerson = new CreatePersonViewModel()
            };

            if (ModelState.IsValid)
            {
                PeopleModel.CreatePerson(person);
            }
            else
            {
                // return supplied info to view to keep form fields filled in
                viewModels.CreatePerson.Name = person.Name;
                viewModels.CreatePerson.Phone = person.Phone;
                viewModels.CreatePerson.City = person.City;
            }

            viewModels.People.List = PeopleModel.List();
            return View("Index", viewModels);
        }


        [HttpGet]
        public IActionResult DeletePerson(int id = 0)
        {
            ViewModelsContainer viewModels = new()
            {
                People = new PeopleViewModel()
            };

            PeopleModel.DeletePerson(id);

            viewModels.People.List = PeopleModel.List();

            return View("Index", viewModels);
        }
    }
}
