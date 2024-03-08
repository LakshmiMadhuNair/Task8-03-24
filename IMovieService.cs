using System;
using System.Linq;
using MyAdoNetProject;
using System.Collections.Generic;

namespace MyBusinessLayer
{

    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void AddMovie(Movie movie);
        void UpdateMovie(int id,Movie movie);
        void DeleteMovie(int id);
        void UpdateMovieRating(MovieRating movieratings);
        double GetAverageRatings(int movieId);
        List<MovieRating> GetMoviesRatedByUser(string username);
    }
    public class MovieService : IMovieService
    
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieRepository.GetAllMovies();
        }

        public Movie GetMovieById(int id)
        {
            return _movieRepository.GetMovieById(id);
        }

        public void AddMovie(Movie movie)
        {
            _movieRepository.AddMovie(movie);
        }

        public void UpdateMovie( int id,Movie movie)
        {
            _movieRepository.UpdateMovie( id,movie);
        }

        public void DeleteMovie(int id)
        {
            _movieRepository.DeleteMovie(id);
        }

        public double GetAverageRatings(int movieId){
            List<int> ratings=_movieRepository.GetAverageRatings(movieId);
            if(ratings.Count==0){
                return 0;
            }
            return ratings.Average();
        }

        public void UpdateMovieRating(MovieRating movieratings){
            _movieRepository.UpdateMovieRating(movieratings);
        }

        // public void PostMovieRating(int id,int rating){
        //     _movieRepository.PostMovieRating(id,rating);
        // }

        public List<MovieRating> GetMoviesRatedByUser(string username){
            return _movieRepository.GetMoviesRatedByUser(username);
        }



 
    }

 
}
