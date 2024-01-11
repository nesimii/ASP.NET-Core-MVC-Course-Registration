using BasicRegistration.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicRegistration.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model = Repository.Applications;
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Apply()
        {
            return View("Apply");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate candidate)
        {
            Repository.Add(candidate);
            return View("Feedback", candidate);
        }
    }
}