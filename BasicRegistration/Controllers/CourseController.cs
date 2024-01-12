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
            if (Repository.Applications.Any(c => c.Email.Equals(candidate.Email)))
                ModelState.AddModelError("", "this user already have a registration");

            if (!ModelState.IsValid) return View("Apply");
            Repository.Add(candidate);
            return View("Feedback", candidate);
        }
    }
}