using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IAsyncRepository<Genre> _genreRepository;
        private readonly IMemoryCache _cache;
        private const string genresCahceKey = "genres";
        private readonly TimeSpan _cacheDuration = TimeSpan.FromDays(20);

        public GenreService(IAsyncRepository<Genre> genreRepository, IMemoryCache cache)
        {
            _genreRepository = genreRepository;
            _cache = cache;
        }

        private async Task<IEnumerable<GenreModel>> CacheCheck(ICacheEntry entry)
        {
            entry.SlidingExpiration = _cacheDuration;
            var genres =  await _genreRepository.ListAllAsync();
            var genrseModel = new List<GenreModel>();
            foreach (var genre in genres)
            {
                genrseModel.Add(new GenreModel
                {
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return genrseModel.OrderBy(g => g.Name);
        }

        public async Task<IEnumerable<GenreModel>> GetAllGenres()
        {
            var genres = await _cache.GetOrCreateAsync(genresCahceKey, CacheCheck);
            return genres;

            //var genres = await _genreRepository.ListAllAsync();
            //var genrseModel = new List<GenreModel>();
            //foreach (var genre in genres)
            //{
            //    genrseModel.Add(new GenreModel
            //    {
            //        Id = genre.Id,
            //        Name = genre.Name
            //    });
            //}
            //return genrseModel.OrderBy(g => g.Name);
        }



        //public async Task<List<MovieCardResponseModel>> GetAllMovies(int Id)
        //{
        //    var movies = await _genreRepository.ListAllAsync(Id);

        //    var result = new List<MovieCardResponseModel>();



        //    foreach (var m in movies)
        //    {
        //        foreach (var c in m.Movies)
        //        {

        //        }
        //    }




        //    return null;
        //}


    }
}
