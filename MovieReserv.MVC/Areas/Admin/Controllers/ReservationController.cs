using Microsoft.AspNetCore.Mvc;
using MovieReserv.MVC.APIResponseMessages;
using MovieReserv.MVC.Areas.Admin.ViewModels.MovieVM;
using MovieReserv.MVC.Areas.Admin.ViewModels.ReservationVM;
using MovieReserv.MVC.Areas.Admin.ViewModels.ShowTimeVM;
using RestSharp;


namespace MovieReserv.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReservationController : Controller
    {
           private readonly RestClient _restClient;
        public ReservationController()
        {
            _restClient = new RestClient("https://localhost:7036/api");
        }
        public async Task<IActionResult> Index()
        {
            var request = new RestRequest("reservations", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<List<ReservationGetVM>>>(request);

            if (!response.IsSuccessful)
            {
                ViewBag.Err = response.Data.ErrorMessage;
                return View();
            }

            return View(response.Data.Data);
        }

        public async Task<IActionResult> Create()
        {
            var request = new RestRequest("auth", Method.Get);
            var mResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<MovieGetVM>>>(request);
            if (!mResponse.IsSuccessful)
            {
                ViewBag.Err = mResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = mResponse.Data.Data;

            var shRequest = new RestRequest("showTime", Method.Get);
            var shResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<ShowTimeGetVM>>>(shRequest);
            if (!shResponse.IsSuccessful)
            {
                ViewBag.Err = shResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = shResponse.Data.Data;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateVM vm)
        {
            //var tRequest = new RestRequest("theaters", Method.Get);
            //var tResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(tRequest);
            //if (!tResponse.IsSuccessful)
            //{
            //    ViewBag.Err = tResponse.Data?.ErrorMessage ?? "Error fetching theaters.";
            //    return View();
            //}

            //ViewBag.Theaters = tResponse.Data.Data;

            var shRequest = new RestRequest("showTime", Method.Get);
            var shResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<ShowTimeGetVM>>>(shRequest);
            if (!shResponse.IsSuccessful)
            {
                ViewBag.Err = shResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = shResponse.Data.Data;

            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest("Reservations", Method.Post);
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
            //var tRequest = new RestRequest("theaters", Method.Get);
            //var tResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(tRequest);
            //if (!tResponse.IsSuccessful)
            //{
            //    ViewBag.Err = tResponse.Data?.ErrorMessage ?? "Error fetching theaters.";
            //    return View();
            //}

            //ViewBag.Theaters = tResponse.Data.Data;


            var shRequest = new RestRequest("showTime", Method.Get);
            var shResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<ShowTimeGetVM>>>(shRequest);
            if (!shResponse.IsSuccessful)
            {
                ViewBag.Err = shResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = shResponse.Data.Data;

            var request = new RestRequest($"reservations/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<ReservationGetVM>>(request);

            if (response == null || !response.IsSuccessful || response.Data == null || response.Data.Data == null)
            {
                string errorMessage = response?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ViewBag.Err = errorMessage;
                return View();
            }

            ReservationUpdateVM vm = new ReservationUpdateVM(
                response.Data.Data.ReservationDate,
                response.Data.Data.AppUserId,
                response.Data.Data.ShowTimeId,
                response.Data.Data.IsDeleted
            );
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ReservationUpdateVM vm)
        {
            //var tRequest = new RestRequest("theaters", Method.Get);
            //var tResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<TheaterGetVM>>>(tRequest);
            //if (!tResponse.IsSuccessful)
            //{
            //    ViewBag.Err = tResponse.Data?.ErrorMessage ?? "Error fetching theaters.";
            //    return View();
            //}

            //ViewBag.Theaters = tResponse.Data.Data;

            var shRequest = new RestRequest("showTime", Method.Get);
            var shResponse = await _restClient.ExecuteAsync<ApiResponseMessage<List<ShowTimeGetVM>>>(shRequest);
            if (!shResponse.IsSuccessful)
            {
                ViewBag.Err = shResponse.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = shResponse.Data.Data;

            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest($"reservations/{id}", Method.Put);

            request.AddJsonBody(new
            {
                EndTime = vm.ReservationDate,
                AppUserId = vm.AppUserId,
                ShowTimeId = vm.ShowTimeId,
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
            var request = new RestRequest($"reservations/{id}", Method.Delete);
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
