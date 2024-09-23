using Microsoft.AspNetCore.Mvc;
using MovieReserv.MVC.APIResponseMessages;
using MovieReserv.MVC.Areas.Admin.ViewModels.ReservationVM;
using MovieReserv.MVC.Areas.Admin.ViewModels.SeatReservationVM;
using RestSharp;

namespace MovieReserv.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SeatReservationController : Controller
    {
        private readonly RestClient _restClient;
        public SeatReservationController()
        {
            _restClient = new RestClient("https://localhost:7036/api");
        }
        public async Task<IActionResult> Index()
        {
            var request = new RestRequest("seatReservations", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<List<SeatReservationGetVM>>>(request);

            if (!response.IsSuccessful)
            {
                ViewBag.Err = response.Data.ErrorMessage;
                return View();
            }

            return View(response.Data.Data);
        }

        public async Task<IActionResult> Create()
        {
            var Request = new RestRequest("reservations", Method.Get);
            var Response = await _restClient.ExecuteAsync<ApiResponseMessage<List<ReservationGetVM>>>(Request); 
            if (!Response.IsSuccessful)
            {
                ViewBag.Err = Response.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = Response.Data.Data;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SeatReservationCreateVM vm)
        {
            var Request = new RestRequest("reservations", Method.Get);
            var Response = await _restClient.ExecuteAsync<ApiResponseMessage<List<ReservationGetVM>>>(Request);
            if (!Response.IsSuccessful)
            {
                ViewBag.Err = Response.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = Response.Data.Data;

            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest("seatReservations", Method.Post);
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
            var Request = new RestRequest("reservations", Method.Get);
            var Response = await _restClient.ExecuteAsync<ApiResponseMessage<List<ReservationGetVM>>>(Request);
            if (!Response.IsSuccessful)
            {
                ViewBag.Err = Response.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = Response.Data.Data;
            var request = new RestRequest($"seatReservations/{id}", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<SeatReservationGetVM>>(request);

            if (response == null || !response.IsSuccessful || response.Data == null || response.Data.Data == null)
            {
                string errorMessage = response?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ViewBag.Err = errorMessage;
                return View();
            }

            SeatReservationUpdateVM vm = new SeatReservationUpdateVM(
                response.Data.Data.SeatNumber,
                response.Data.Data.IsBooked,
                response.Data.Data.ReservationId,
                response.Data.Data.IsDeleted
            );
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, SeatReservationUpdateVM vm)
        {
            var Request = new RestRequest("reservations", Method.Get);
            var Response = await _restClient.ExecuteAsync<ApiResponseMessage<List<ReservationGetVM>>>(Request);
            if (!Response.IsSuccessful)
            {
                ViewBag.Err = Response.Data?.ErrorMessage ?? "Error fetching movies.";
                return View();
            }

            ViewBag.Movies = Response.Data.Data;
            if (!ModelState.IsValid) return View(vm);

            var request = new RestRequest($"seatReservations/{id}", Method.Put);

            request.AddJsonBody(new
            {
                Name = vm.SeatNumber,
                Location = vm.IsBooked,
                TotalSeats = vm.ReservationId,
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
            var request = new RestRequest($"seatReservations/{id}", Method.Delete);
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
