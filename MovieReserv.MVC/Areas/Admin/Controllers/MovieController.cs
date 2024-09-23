using Microsoft.AspNetCore.Mvc;
using MovieReserv.MVC.APIResponseMessages;
using MovieReserv.MVC.Areas.Admin.ViewModels.MovieVM;
using RestSharp;

namespace MovieReserv.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MovieController : Controller
    {
        private readonly RestClient _restClient;
        public MovieController()
        {
            _restClient = new RestClient("https://localhost:7036/api");
        }
        public async Task<IActionResult> Index()
        {
            var request = new RestRequest("movies", Method.Get);
            var response = await _restClient.ExecuteAsync<ApiResponseMessage<List<MovieGetVM>>>(request);

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
        public async Task<IActionResult> Create(MovieCreateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var movieRequest = new RestRequest("movies", Method.Post);
            movieRequest.AddJsonBody(vm); 

            var movieResponse = await _restClient.ExecuteAsync<ApiResponseMessage<object>>(movieRequest);

            if (movieResponse == null || !movieResponse.IsSuccessful)
            {
                var errorMessage = movieResponse?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ModelState.AddModelError("", errorMessage);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var movieRequest = new RestRequest($"movies/{id}", Method.Get);
            var movieResponse = await _restClient.ExecuteAsync<ApiResponseMessage<MovieGetVM>>(movieRequest);

            if (movieResponse == null || !movieResponse.IsSuccessful || movieResponse.Data == null || movieResponse.Data.Data == null)
            {
                string errorMessage = movieResponse?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ViewBag.Err = errorMessage;
                return View(); 
            }

            MovieUpdateVM vm = new MovieUpdateVM(
                movieResponse.Data.Data.Title,             
                movieResponse.Data.Data.Description,       
                movieResponse.Data.Data.Duration,          
                movieResponse.Data.Data.IsDeleted,         
                movieResponse.Data.Data.Genre,             
                movieResponse.Data.Data.ReleaseDate         
            );

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, MovieUpdateVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var movieRequest = new RestRequest($"movies/{id}", Method.Put);

            movieRequest.AddJsonBody(new
            {
                Title = vm.Title,
                Description = vm.Description,
                IsDeleted = vm.IsDeleted,
                Genre = vm.Genre,
                Duration = vm.Duration,
                ReleaseDate = vm.ReleaseDate 
            });

            var movieResponse = await _restClient.ExecuteAsync<ApiResponseMessage<object>>(movieRequest);

            if (!movieResponse.IsSuccessful)
            {
                string errorMessage = movieResponse?.Data?.ErrorMessage ?? "An unexpected error occurred.";
                ModelState.AddModelError("", errorMessage);
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var request = new RestRequest($"movies/{id}", Method.Delete);
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
