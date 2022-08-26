using Microsoft.AspNetCore.Mvc;
using MVCBasics.Models;
using MVCBasics.ViewModels;

namespace MVCBasics.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult PeopleList()
        {
            PeopleViewModel viewModel = PeopleModel.List();
            return View("_PeopleList", viewModel);
        }


        [HttpPost]
        public IActionResult GetPerson(int id)
        {
            PeopleViewModel viewModel = PeopleModel.GetPerson(id);
            return View("_PersonDetails", viewModel);
        }


        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            PeopleViewModel viewModel = PeopleModel.DeletePerson(id);

            if (viewModel.StatusCode == 400) 
            {
                return BadRequest(); // Setting status code to anything other than 2** will trigger the 'error' part of the javascript/ajax call.
            }
            else
            {
                return Ok();
            }
        }
    }
}
