using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Movie>(ConfigureMovie);
            modelBuilder.Entity<Trailer>(ConfigureTrailer);
            modelBuilder.Entity<Cast>(ConfigureCast);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<Crew>(ConfigureCrew);
            modelBuilder.Entity<Review>(ConfigureReview);
            modelBuilder.Entity<User>(ConfigureUser);



            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies)
               .UsingEntity<Dictionary<string, object>>("MovieGenre",
                   m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                   g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));



            //modelBuilder.Entity<MovieCast>()
            //    .HasKey(t => new { t.MovieId, t.CastId, t.Character });
            //modelBuilder.Entity<MovieCast>()
            //    .HasOne(mc => mc.Movie)
            //    .WithMany(m => m.MovieCast)
            //    .HasForeignKey(mc => mc.MovieId);
            //modelBuilder.Entity<MovieCast>()
            //    .HasOne(mc => mc.Cast)
            //    .WithMany(m => m.MovieCast)
            //    .HasForeignKey(mc => mc.CastId);


        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => new {u.Id });
            builder.Property(u => u.FirstName).HasMaxLength(128);
            builder.Property(u => u.LastName).HasMaxLength(128);
            builder.Property(u => u.DateOfBirth).HasPrecision(7);
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.HashedPassword).HasMaxLength(1024);
            builder.Property(u => u.Salt).HasMaxLength(1024);
            builder.Property(u => u.PhoneNumber).HasMaxLength(16);
            builder.Property(u => u.TwoFactorEnabled);
            builder.Property(u => u.LockoutEndDate).HasPrecision(7);
            builder.Property(u => u.LastLoginDateTime).HasPrecision(7);
            builder.Property(u => u.IsLocked).HasDefaultValue(false);
            builder.Property(u => u.AccessFailedCount);
            builder.HasIndex(u => u.Salt).IsUnique();
        }

        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(r => new { r.MovieId, r.UserId });
            builder.Property(r => r.Rating).HasColumnType("decimal(3,2)");
            builder.Property(r => r.ReviewText);
        }


        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mc => new { mc.MovieId, mc.CrewId, mc.Department, mc.Job });
            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCrew).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Crew).WithMany(mc => mc.MovieCrew).HasForeignKey(mc => mc.CrewId);
            builder.Property(c => c.Department).HasMaxLength(128);
            builder.Property(c => c.Job).HasMaxLength(128);
        }

        private void ConfigureCrew(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable("Crew");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Name);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.TmdbUrl);
            builder.Property(c => c.Gender);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureCast(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Cast");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Name);
            builder.Property(c => c.Name).HasMaxLength(128);
            builder.Property(c => c.TmdbUrl);
            builder.Property(c => c.Gender);
            builder.Property(c => c.ProfilePath).HasMaxLength(2084);
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character });
            builder.HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCast).HasForeignKey(mc => mc.MovieId);
            builder.HasOne(mc => mc.Cast).WithMany(mc => mc.MovieCast).HasForeignKey(mc => mc.CastId);
        }


        private void ConfigureTrailer(EntityTypeBuilder<Trailer> builder)
        {
            builder.ToTable("Trailer");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(2084);
            builder.Property(t => t.TrailerUrl).HasMaxLength(2084);

        }

        private void ConfigureMovie(EntityTypeBuilder<Movie> builder)
        {
            // we specify the rules for Movie Entity
            builder.ToTable("Movie");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Title).HasMaxLength(256);
            builder.Property(m => m.Overview).HasMaxLength(4096);
            builder.Property(m => m.Tagline).HasMaxLength(512);
            builder.Property(m => m.ImdbUrl).HasMaxLength(2084);
            builder.Property(m => m.TmdbUrl).HasMaxLength(2084);
            builder.Property(m => m.PosterUrl).HasMaxLength(2084);
            builder.Property(m => m.BackdropUrl).HasMaxLength(2084);
            builder.Property(m => m.OriginalLanguage).HasMaxLength(64);
            builder.Property(m => m.Price).HasColumnType("decimal(5, 2)").HasDefaultValue(9.9m);
            builder.Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Ignore(m => m.Rating);
        }
    }
}
