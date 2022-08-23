using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class PeopleController : Controller
    {
        public IActionResult Index()
        {
            PeopleViewModel viewModel = new();
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult Search(string search)
        {

            PeopleViewModel viewModel = People.Search(search);
            return View("Index", viewModel);
        }


        public IActionResult CreatePerson(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                // Create person...
            }
            else
            {
                // Check ModelState.Errors property
            }

            return View("Index");
        }
    }
}
