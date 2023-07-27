using BusinessLogicLayer.Services;
using DataAccessLayer.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MedicineManagement.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // GET request for the login page
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Login model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // If the model state is not valid, return the view with the current model
                    return View(model);
                }

                // Authenticate the user using the ILoginService
                var user = await _service.Authenticate(model);

                if (user == null)
                {
                    // If authentication fails, add a model error and return the view with the current model
                    ModelState.AddModelError("Email", "Invalid email or password");
                    return View(model);
                }

                if (user.IsAdmin)
                {
                    // If the user is an admin, redirect to the home page for admins
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If the user is not an admin, redirect to the privacy page for regular users
                    return RedirectToAction("Privacy", "Home");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the login process
                // You can log the error or perform any other actions here
                // For now, simply return the view with the current model
                return View(model);
            }
        }
    }
}
