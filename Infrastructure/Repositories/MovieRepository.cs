using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.ServiceInterfaces;



namespace Infrastructure.Repositories
{

    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Movie>> GetTop30HighestGrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            // skip , take
            // Pagesize =20
            // 1-20, 21-40, 41-60
            // 1  skip(pagenumber-1).take(20)
            // 2 skip( )    20   (2-1)*PageSize
            // 3 skip(3-1)*pagesize
            return movies;
        }
        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCast).ThenInclude(m => m.Cast)
            .Include(m=>m.Genres)
            .Include(r=>r.Review)
            .FirstOrDefaultAsync(m => m.Id == id);


            //var movieRating = await _dbContext.Review.Where(r=>r.MovieId == id).DefaultIfEmpty()
            //                  .AverageAsync(r => r == null ? 0 : r.Rating);

            //if (movieRating > 0) movie.Rating = movieRating;


            return movie;

        }

        public async Task<IEnumerable<Genre>> ListAllMoviesAsync(int Id)
        {
            //var movie = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Name == name).ToListAsync();

            var movie = await _dbContext.Genres.Where(g => g.Id == Id).Include(g => g.Movies).ToListAsync();

            return movie;
        }




        //Task<IEnumerable<Genre>> ListAllAsync(int Id);

        //public  async Task<IEnumerable<Genre>> ListAllAsync(int Id)
        //{
        //    //var movie = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Name == name).ToListAsync();

        //    var movie = await _dbContext.Genres.Where(g => g.Id == Id).Include(g => g.Movies).ToListAsync();

        //    return movie;

        //}
    }
}
