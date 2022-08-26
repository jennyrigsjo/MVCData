using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            PCViewModels viewModels = new()
            {
                People = PeopleModel.List()
            };

            return View(viewModels);
        }


        [HttpPost]
        public IActionResult Search(string search)
        {
            PCViewModels viewModels = new()
            {
                People = PeopleModel.Search(search)
            };

            return View("Index", viewModels);
        }


        [HttpPost]
        public IActionResult CreatePerson(CreatePersonViewModel person)
        {
            PCViewModels viewModels = new();

            if (ModelState.IsValid)
            {
                viewModels.People = PeopleModel.CreatePerson(person);
            }
            else
            {
                // return supplied info to view to keep form fields filled in
                viewModels.CreatePerson.Name = person.Name;
                viewModels.CreatePerson.Phone = person.Phone;
                viewModels.CreatePerson.City = person.City;
            }

            return View("Index", viewModels);
        }


        [HttpGet]
        public IActionResult DeletePerson(int id)
        {
            PCViewModels viewModels = new()
            {
                People = PeopleModel.DeletePerson(id)
            };

            return View("Index", viewModels);
        }
    }
}
