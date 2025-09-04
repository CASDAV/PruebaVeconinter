using Microsoft.AspNetCore.Mvc;
using Microsoft.Kiota.Abstractions;
using PersonalDataManagementSystem.BackendClient;
using PersonalDataManagementSystem.Front.Models;

namespace PersonalDataManagementSystem.Front.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ApiClient _apiClient;

        public ClientsController(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }


        [HttpGet]
        public IActionResult Clients()
        {
            try
            {
                var model = new ClientsModel(_apiClient);
                
                return View(model);
            }
            catch (ApiException ex) when (ex.ResponseStatusCode == 401)
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}
