using MVCData.Models;
using Microsoft.AspNetCore.Mvc;
using MVCData.ViewModels;
using MVCData.Data;
using Microsoft.EntityFrameworkCore;

namespace MVCData.Controllers
{
    public class AjaxController : Controller
    {
        readonly ApplicationDBContext Database;
        public AjaxController(ApplicationDBContext database)
        {
            Database = database;
        }
        public IActionResult Index()
        {
            
            return View();
        }


        public IActionResult PeopleList()
        {
            PeopleViewModel viewModel = new()
            {
                List = Database.People.ToList()
            };
            return View("_PeopleList", viewModel);
        }

        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            
            var personToDelete = Database.People.FirstOrDefault(x => x.ID == id);

            if (personToDelete != null)
            {
                Database.People.Remove(personToDelete);
                Database.SaveChanges();
                return Json(id + " was deleted, status: " + StatusCode(200).StatusCode);
            }

            return Json("Error , status: " + StatusCode(400).StatusCode);

        }
        [HttpPost]
        public IActionResult GetDetails(int id)
        {
            
            Person person = Database.People.Include(x => x.City).Include(x => x.Languages).
                FirstOrDefault(x => x.ID == id);

            if (person == null)
            {
                ViewBag.ERROR = "This Person Does Not Exist";
            }
            return View("_AjaxGetDetails", person);
        }


    }



}
