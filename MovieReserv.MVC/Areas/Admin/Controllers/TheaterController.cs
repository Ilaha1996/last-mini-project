using Microsoft.AspNetCore.Mvc;
using MovieReserv.MVC.APIResponseMessages;
using MovieReserv.MVC.Areas.Admin.ViewModels.TheaterVM;
using RestSharp;

namespace MovieReserv.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TheaterController : Controller
    {

        private readonly RestClient _restClient;
        public TheaterController()
        {
            _restClient = new RestClient("https://localhost:7036/api");
        }
        public async Task<IActionResult> Index()
        {
            var request = new RestRequest("theaters", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(request);

            if (!response.IsSuccessful)
            {
                ViewBag.Err = response.Data.ErrorMessage;
                return View();
            }

            return View(response.Data.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TheaterCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest("theaters", Method.Post);
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

        public async Task<IActionResult> Update(int id)
        {
            var request = new RestRequest($"theaters/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<TheaterGetVM>>(request);

            if (response == null || !response.IsSuccessful || response.Data == null || response.Data.Data == null)
            {
                string errorMessage = response?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ViewBag.Err = errorMessage;
                return View();
            }

            TheaterUpdateVM vm = new TheaterUpdateVM(
                response.Data.Data.Name,
                response.Data.Data.Location,
                response.Data.Data.TotalSeats,
                response.Data.Data.IsDeleted
            );
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, TheaterUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest($"theaters/{id}", Method.Put);

            request.AddJsonBody(new
            {
                Name = vm.Name,
                Location = vm.Location,
                TotalSeats = vm.TotalSeats,
                IsDeleted = vm.IsDeleted             
            });

            var response = await _restClient.ExecuteAsync<ApiResponseMessage<object>>(request);

            if (!response.IsSuccessful)
            {
                string errorMessage = response?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ModelState.AddModelError("", errorMessage);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest($"theaters/{id}", Method.Delete);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<object>>(request);

            if (!response.IsSuccessful)
            {
                ViewBag.Err = response.Data.ErrorMessage;
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}
