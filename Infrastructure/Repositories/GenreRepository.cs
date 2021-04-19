using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenreRepository: EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }



        //public override async Task<IEnumerable<Genre>> ListAllAsync(int Id)
        //{
        //    //var movie = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Name == name).ToListAsync();

        //    var movie = await _dbContext.Genres.Where(g => g.Id == Id).Include(g => g.Movies).ToListAsync();

        //    return movie;

        //}



    }
}
