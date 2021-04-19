using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models.Response
{
    public class MovieDetailsResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string Tagline { get; set; }
        public decimal Budget { get; set; }
        public decimal Revenue { get; set; }
        public string ImdbUrl { get; set; }
        public string TmdbUrl { get; set; }
        public string PosterUrl { get; set; }
        public string BackdropUrl { get; set; }
        public string OriginalLanguage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
        public decimal? Rating { get; set; }
        public List<CastDetailsResponseModel> Casts { get; set; }

        public List<ReviewMovieResponseModel> Review { get; set; }

        public List<GenreForParticularMovieModel> Genre { get; set; }

        //public class CastResponseModel
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Gender { get; set; }
        //    public string TmdbUrl { get; set; }
        //    public string ProfilePath { get; set; }
        //    public string Character { get; set; 

    }


    public class CastDetailsResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
        public List<MovieDetailsResponseModel> MovieId { get; set; }
        public int CastId { get; set; }
        public string Character { get; set; }
        public List<MovieDetailsResponseModel> Movie { get; set; }

    }

    //public class CastDetailsResponseModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Gender { get; set; }
    //    public string TmdbUrl { get; set; }
    //    public string ProfilePath { get; set; }
    //    public int MovieId { get; set; }
    //    public int CastId { get; set; }
    //    public string Character { get; set; }
    //    public IEnumerable<MovieResponseModel> Movies { get; set; }

    //}

    //public class MovieResponseModel
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string PosterUrl { get; set; }
    //    public DateTime ReleaseDate { get; set; }
    //}

    public class GenreForParticularMovieModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //public class MovieChartResponseModel
    //{
    //    public int MovieId { get; set; }
    //    public string Title { get; set; }
    //    public int PurchaseCount { get; set; }
    //}

    //public class FavoriteResponseModel
    //{
    //    public int UserId { get; set; }
    //    public List<FavoriteMovieResponseModel> FavoriteMovies { get; set; }

    //    public class FavoriteMovieResponseModel : MovieResponseModel
    //    {
    //    }
    //}

    //public class CastDetailsResponseModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Gender { get; set; }
    //    public string TmdbUrl { get; set; }
    //    public string ProfilePath { get; set; }
    //    public IEnumerable<MovieResponseModel> Movies { get; set; }
    //}

    //public class ReviewResponseModel
    //{
    //    public int UserId { get; set; }
    //    public List<ReviewMovieResponseModel> MovieReviews { get; set; }
    //}

    public class ReviewMovieResponseModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public string Name { get; set; }
    }
}



