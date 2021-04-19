using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")] //attribute routing 
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly ICastService _castService;
        public MoviesController(IMovieService movieService, ICastService castService)
        {
            _movieService = movieService;
            _castService = castService;
        }

        [HttpGet]
        [Route("toprevenue")] //attribute based routing 
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.Get30HighestGrossing();

            if (!movies.Any())
            {
                return NotFound("We did not find any movies");
            }
            return Ok(movies);

            //System.Text.Json in .NET Core 3
            //previous versions of .NET 1,2 and previous older. net framework, Newtonsoft(3rd party library)
            ///Serialiaztion, convert ur c# object into json objects
            //De-Serialiaztion ,convert json objetcs to c#

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> MoviesDetails(int id )
        {
            var movies = await _movieService.GetMovieDetailsAsync(id);

            if (movies==null)
            {
                return NotFound("We did not find information about this movie");
            }
            return Ok(movies);
        }

  


        [HttpGet]
        [Route("Cast/{id}")]
        public async Task<IActionResult> CastDetails(int id)
        {
            var cast = await _castService.GetCastAsync(id);
            
            if(cast == null)
            {
                return NotFound("We did not find information about this actor/actress");
            }

            return Ok(cast);
        }


        [HttpGet]
        [Route("Genres/{genreId}")]
        public async Task<IActionResult> GenreDetails(int genreId)
        {
            var genres = await _movieService.GetAllMovies(genreId);
            if (!genres.Any())
            {
                return NotFound("We did not find movies about this genres");
            }
            return Ok(genres);
        }




    }
}
