using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
     public class CastRepository: EfRepository<Cast>,ICastRepository
    {

        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public override async Task<Cast> GetByIdAsync(int id)
        {
            var cast = await _dbContext.Casts.Include(c => c.MovieCast)
            .ThenInclude(c => c.Movie)
           .FirstOrDefaultAsync(c => c.Id == id);

            //var cast = await _dbContext.Casts
            //.FirstOrDefaultAsync(c => c.Id == id);

            return cast;

        }

    }
}
