using Microsoft.EntityFrameworkCore;
using philipsgodtepose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Repositories
{
    public static class MovieRepository
    {
        private static List<Movie> _movies = new List<Movie>();

        /// <summary>
        /// Add movie to database
        /// </summary>
        /// <param name="a"></param>
        public static void Add(Movie a)
        {
            DatabaseManager.movieContext!.Movies.Add(a);
            DatabaseManager.movieContext!.SaveChanges();
        }

        /// <summary>
        /// Get all movies from database
        /// </summary>
        /// <returns>returns all movies</returns>
        public static List<Movie> GetAll()
        {
            return DatabaseManager.movieContext!.Movies.Include(x => x.Actors).Include(x => x.Director).Include(x => x.Genre).ToList();
        }

        /// <summary>
        /// Get movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns movie</returns>
        public static Movie? GetById(int id)
        {
            //return _movies.Find(a => a.Id == id);
            return DatabaseManager.movieContext!.Movies.Where(x => x.Id == id).Include(x => x.Actors).Include(x => x.Director).Include(x => x.Genre).First();
        }

        /// <summary>
        /// Edit movie from database
        /// </summary>
        /// <param name="a"></param>
        public static void Update(Movie a)
        {
            Movie movie = DatabaseManager.movieContext!.Movies.Where(a => a.Id == a.Id).First();
            movie.Name = a.Name ?? movie.Name;
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Delete movie from the database
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            try
            {
                Movie movie = DatabaseManager.movieContext!.Movies.Where(a => a.Id == id).First();
                DatabaseManager.movieContext.Movies.Remove(movie);
            }
            catch (Exception ex) { }
            DatabaseManager.movieContext.SaveChanges();
        }
    }
}
