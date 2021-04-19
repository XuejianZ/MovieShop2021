using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Response;
namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<CastDetailsResponseModel> GetCastAsync(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);

            var castResult = new CastDetailsResponseModel();

            
            castResult.Name = cast.Name;
            castResult.Gender = cast.Gender;
            castResult.TmdbUrl = cast.TmdbUrl;
            castResult.ProfilePath = cast.ProfilePath;
            castResult.Id = cast.Id;
            castResult.CastId = cast.Id;

            castResult.MovieId = new List<MovieDetailsResponseModel>();

            castResult.Movie = new List<MovieDetailsResponseModel>();

            
            foreach ( var movieCast in cast.MovieCast)
            {

                castResult.Movie.Add(
                    new MovieDetailsResponseModel
                    {

                        Title = movieCast.Movie.Title,
                        PosterUrl = movieCast.Movie.PosterUrl,
                        Overview = movieCast.Movie.Overview,
                        Id= movieCast.Movie.Id
                        

                    }); 

               

            }

            return castResult;

        }
    }
}
