using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")] //attribute routing 
    public class GenresController : Controller
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
      
        public async Task<IActionResult> GenreList()
        {
            var genres = await _genreService.GetAllGenres();
            if (genres == null)
            {
                return NotFound("We did not get the genre list ");
            }

            return Ok(genres);
        }

    }
}
