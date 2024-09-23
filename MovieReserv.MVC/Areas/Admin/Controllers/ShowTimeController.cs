using Microsoft.AspNetCore.Mvc;
using MovieReserv.MVC.APIResponseMessages;
using MovieReserv.MVC.Areas.Admin.ViewModels.MovieVM;
using MovieReserv.MVC.Areas.Admin.ViewModels.ShowTimeVM;
using MovieReserv.MVC.Areas.Admin.ViewModels.TheaterVM;
using RestSharp;

namespace MovieReserv.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShowTimeController : Controller
    {
        private readonly RestClient _restClient;
        public ShowTimeController()
        {
            _restClient = new RestClient("https://localhost:7036/api");
        }
        public async Task<IActionResult> Index()
        {
            var request = new RestRequest("showTimes", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<List<ShowTimeGetVM>>>(request);

            if (!response.IsSuccessful)
            {
                ViewBag.Err = response.Data.ErrorMessage;
                return View();
            }

            return View(response.Data.Data);
        }

        public async Task<IActionResult> Create()
        {
            var tRequest = new RestRequest("theaters", Method.Get);
            var tResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(tRequest);
            if (!tResponse.IsSuccessful)
            {
                ViewBag.Err = tResponse.Data?.ErrorMessage ?? "Error fetching theaters.";
                return View();
            }

            ViewBag.Theaters = tResponse.Data.Data;

            var mRequest = new RestRequest("movies", Method.Get);
            var mResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<MovieGetVM>>>(mRequest); // Assuming you're fetching MovieGetVM
            if (!mResponse.IsSuccessful)
            {
                ViewBag.Err = mResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = mResponse.Data.Data;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ShowTimeCreateVM vm)
        {
            var tRequest = new RestRequest("theaters", Method.Get);
            var tResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(tRequest);
            if (!tResponse.IsSuccessful)
            {
                ViewBag.Err = tResponse.Data?.ErrorMessage ?? "Error fetching theaters.";
                return View();
            }

            ViewBag.Theaters = tResponse.Data.Data;

            var mRequest = new RestRequest("movies", Method.Get);
            var mResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<MovieGetVM>>>(mRequest); // Assuming you're fetching MovieGetVM
            if (!mResponse.IsSuccessful)
            {
                ViewBag.Err = mResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = mResponse.Data.Data;

            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest("showTimes", Method.Post);
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
            var tRequest = new RestRequest("theaters", Method.Get);
            var tResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(tRequest);
            if (!tResponse.IsSuccessful)
            {
                ViewBag.Err = tResponse.Data?.ErrorMessage ?? "Error fetching theaters.";
                return View();
            }

            ViewBag.Theaters = tResponse.Data.Data;

            var mRequest = new RestRequest("movies", Method.Get);
            var mResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<MovieGetVM>>>(mRequest); // Assuming you're fetching MovieGetVM
            if (!mResponse.IsSuccessful)
            {
                ViewBag.Err = mResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = mResponse.Data.Data;

            var request = new RestRequest($"showTimes/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<ShowTimeGetVM>>(request);

            if (response == null || !response.IsSuccessful || response.Data == null || response.Data.Data == null)
            {
                string errorMessage = response?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ViewBag.Err = errorMessage;
                return View();
            }

            ShowTimeUpdateVM vm = new ShowTimeUpdateVM(
                response.Data.Data.StartTime,
                response.Data.Data.EndTime,
                response.Data.Data.MovieId,
                response.Data.Data.TheaterId,
                response.Data.Data.IsDeleted
            );
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ShowTimeUpdateVM vm)
        {
            var tRequest = new RestRequest("theaters", Method.Get);
            var tResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(tRequest);
            if (!tResponse.IsSuccessful)
            {
                ViewBag.Err = tResponse.Data?.ErrorMessage ?? "Error fetching theaters.";
                return View();
            }

            ViewBag.Theaters = tResponse.Data.Data;

            var mRequest = new RestRequest("movies", Method.Get);
            var mResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<MovieGetVM>>>(mRequest); // Assuming you're fetching MovieGetVM
            if (!mResponse.IsSuccessful)
            {
                ViewBag.Err = mResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = mResponse.Data.Data;

            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest($"showTimes/{id}", Method.Put);

            request.AddJsonBody(new
            {
                StartTime = vm.StartTime,
                EndTime = vm.EndTime,
                MovieId = vm.MovieId,
                TheaterId = vm.TheaterId,
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
            var request = new RestRequest($"showTimes/{id}", Method.Delete);
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
