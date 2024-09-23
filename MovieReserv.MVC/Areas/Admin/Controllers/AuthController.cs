using Microsoft.AspNetCore.Mvc;
using MovieReserv.MVC.APIResponseMessages;
using MovieReserv.MVC.Areas.Admin.ViewModels.AuthVM;
using RestSharp;

namespace MovieReserv.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly RestClient _restClient;
        public AuthController()
        {
            _restClient = new RestClient("https://localhost:7036/api");
        }
   
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVM vm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid credentials");
                return View();
            }

            var request = new RestRequest("auth", Method.Post);
            request.AddJsonBody(vm);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<object>>(request);

            if (response == null || !response.IsSuccessful)
            {
                var errorMessage = response?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ModelState.AddModelError("", errorMessage);
                return View(vm);
            }

            return RedirectToAction("Index");            
          
        }
    }
}
