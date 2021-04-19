using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using AutoMapper;
namespace Infrastructure.Services
{
    public class MovieService : IMovieService 
    {
        private readonly IMovieRepository _movieRepository;
        
        public   MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
          
        }


        public async Task<MovieDetailsResponseModel> GetMovieDetailsAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);

            var movieResult = new MovieDetailsResponseModel();

            movieResult.Casts = new List<CastDetailsResponseModel>();

            movieResult.Genre = new List<GenreForParticularMovieModel>();

            //Cast
            foreach (var cast in movie.MovieCast)
            {
                    movieResult.Casts.Add(
                    new CastDetailsResponseModel
                    {
                        Id = cast.CastId,
                        Character = cast.Character,
                        Name = cast.Cast.Name,
                        ProfilePath= cast.Cast.ProfilePath
                    });
            }

            // Genre
            foreach ( var genre in movie.Genres)
            {
                movieResult.Genre.Add(
                    new GenreForParticularMovieModel
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    });
            }

            movieResult.Id = movie.Id;
            movieResult.ReleaseDate =(DateTime) movie.ReleaseDate;
            movieResult.RunTime = movie.RunTime;
            movieResult.Revenue = (decimal)movie.Revenue;
            movieResult.Budget = (decimal) movie.Budget;
            movieResult.PosterUrl = movie.PosterUrl;
            movieResult.Title = movie.Title;
            movieResult.Overview = movie.Overview;

            int count=0;
            decimal total = 0;
            foreach (var review in movie.Review)
            {
                total += review.Rating;
                count++;
            }

            decimal avgRating = total / count;

            movieResult.Rating = avgRating;

            return movieResult;
        }




        public async Task<List<MovieCardResponseModel>> Get30HighestGrossing()
        {
            var movies = await _movieRepository.GetTop30HighestGrossingMovies();

            var result = new List<MovieCardResponseModel>();

            foreach (var movie in movies)
            {
                result.Add(
                new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return result;
        }

       
        public void CreateMovie(MovieCreateRequestModel model)
        {
            // take model and convert it to Movie Entity and send it to repository
            // if repository saves successfully return true/id:2
        }

        public async Task<List<MovieCardResponseModel>> GetAllMovies(int Id)
        {
            var movies = await _movieRepository.ListAllMoviesAsync(Id);

            var result = new List<MovieCardResponseModel>();


            foreach (var m in movies)
            {
                foreach (var c in m.Movies)
                {
                    result.Add(
                        new MovieCardResponseModel
                        {
                            Id= c.Id,
                            Title = c.Title,
                            PosterUrl = c.PosterUrl
                        });

                }
            }

            return result;
        }
    }
}
