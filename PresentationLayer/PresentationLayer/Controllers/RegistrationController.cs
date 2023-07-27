using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Registration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!_registrationService.IsEmailAvailable(model.Email))
            {
                ModelState.AddModelError("Email", "This email address is already registered.");
                return View(model);
            }

            var registration = new Registration
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                ContactNo = model.ContactNo,
                Password = model.Password,
                ForgotPassword = model.ForgotPassword
            };

            _registrationService.Register(registration);

            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }

}
