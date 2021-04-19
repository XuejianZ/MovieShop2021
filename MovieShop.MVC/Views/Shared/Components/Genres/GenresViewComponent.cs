using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using ApplicationCore.ServiceInterfaces;
namespace MovieShop.MVC.Views.Components.Genres
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;

        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _genreService.GetAllGenres();
            return View(genres);
        }

        //[HttpGet]
        //public async Task<IActionResult> GenreDetails(string name)
        //{
        //    var movies = await _genreService.GetAllMovies(name);
        //    return View(movies);
        //}




    }
}
