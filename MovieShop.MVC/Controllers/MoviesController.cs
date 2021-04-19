using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Response;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        // private MovieService _movieService;
        private readonly IMovieService _movieService;
        //When you programing is running , the IMovieService is repalced by implementation
        private readonly ICastService _castService;

        private readonly IGenreService _genreService;


        public MoviesController(IMovieService movieService, ICastService castService, IGenreService genreService)
        {
            // 1.Constructir injection***** inject the implemenation into the 
            //constructor of the class
            //_movieService = new MovieService();
            _movieService = movieService;
            _castService = castService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index()
        {
            //private MovieService _movieService;
            //It will look for a veiw with name called index(becasue the action method name is index )
            //return index2, TestView
            // 1.ViewBag - built in MVC  
            //2.ViewData - built in MVC
            //3.Strongly typed models ****
            //send list of top 30 movies to teh view 
            //id, title, posterlurl
            // ViewBag.PageTitle = "Top 30 Grosiing Movies";
            var movies = await _movieService.Get30HighestGrossing();
            return View(movies);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            //_movieService.
            // should call Movie Service to get the details of the Movie that includes Movie Details, Cast for that Movie, Rating for that Movie
            var movie = await _movieService.GetMovieDetailsAsync(id);
            return View(movie);
        }


        [HttpGet]
        public async Task<IActionResult> CastDetails(int id)
        {
            var cast = await _castService.GetCastAsync(id);
            return View(cast);
        }


        [HttpGet]
        public async Task<IActionResult> GenreDetails(int Id)
        {
            var movies = await _movieService.GetAllMovies(Id);
            return View(movies);
        }



        //we want to show blank page with all the inputs
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        //receive Movie information from View then submitted 
        public IActionResult Create(MovieCreateRequestModel model)
        {
            _movieService.CreateMovie(model);
            return RedirectToAction("Index");
        }

    }
}
