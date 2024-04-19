using _413FinalExam_Demars.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.Diagnostics;

namespace _413FinalExam_Demars.Controllers
{
    public class HomeController : Controller
    {
        private IFinalRepository _repo;

        public HomeController(IFinalRepository temp)
        {
            _repo = temp;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult ListofEntertainerstoBook()
        {
            var entertainers = _repo.GetEntertainers().ToList();
            return View(entertainers);
        }

        public IActionResult EntertainerDetails()
        {
            var entertainers = _repo.GetEntertainers().ToList();
            return View(entertainers);
        }

        // Get action for the NewEntertainer View
        [HttpGet]
        public IActionResult NewEntertainer()
        {

            return View(new Entertainer());             // return the view with a new Entertainer model so the EntertainerId defaults to 0 for a new entry

        }

        // Post action for the NewEntertainer View
        [HttpPost]
        public IActionResult NewEntertainer(Entertainer e)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEntertainer(e);
            }

            return View("Confirmation");
        }

        // Get action for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Entertainers.Single(x => x.EntertainerId == id);

            return View("NewEntertainer", recordToEdit);
        }

        // Post action for Edit
        [HttpPost]
        public IActionResult Edit(Entertainer updatedEntertainer)
        {
            if (ModelState.IsValid)
            {
                _repo.EditEntertainer(updatedEntertainer);

                return RedirectToAction("EntertainerDetails");
            }
            else
            {
                return View("NewEntertainer", updatedEntertainer);
            }
        }

         // Get Action for Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Entertainers.Single(x => x.EntertainerId == id);

            return View(recordToDelete);
        }

        // Post action for Delete
        [HttpPost]
        public IActionResult Delete(Entertainer deletedEntertainer)
        {
            _repo.DeleteEntertainer(deletedEntertainer);

            return RedirectToAction("EntertainerDetails");
        }

    }
}
