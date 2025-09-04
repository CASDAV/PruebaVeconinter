using Microsoft.AspNetCore.Mvc;
using PersonalDataManagementSystem.BackendClient;
using PersonalDataManagementSystem.BackendClient.Models;
using PersonalDataManagementSystem.Front.Models;

namespace PersonalDataManagementSystem.Front.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApiClient _apiClient;

        public AccountController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var loginRequest = new LoginRequest { UserName = model.UserName, Password = model.Password };
                var tokenResponse = await _apiClient.Api.Authentication.Login.PostAsync(loginRequest);
                if (!string.IsNullOrWhiteSpace(tokenResponse))
                {
                    HttpContext.Session.SetString("AccessToken", tokenResponse);
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            return View(model);

        }

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

    }
}
