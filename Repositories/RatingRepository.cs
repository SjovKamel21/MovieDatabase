using Microsoft.EntityFrameworkCore;
using philipsgodtepose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Repositories
{
    public static class RatingRepository
    {
        private static List<Rating> _ratings = new List<Rating>();

        /// <summary>
        /// Add rating to the database
        /// </summary>
        /// <param name="a"></param>
        public static void Add(Rating a)
        {
            DatabaseManager.movieContext!.Ratings.Add(a);
            DatabaseManager.movieContext!.SaveChanges();
        }

        /// <summary>
        /// Get all ratings from the database
        /// </summary>
        /// <returns>returns all ratings</returns>
        public static List<Rating> GetAll()
        {
            return DatabaseManager.movieContext!.Ratings.ToList();
        }

        /// <summary>
        /// Get rating from the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns rating</returns>
        public static Rating? GetById(int id)
        {
            return DatabaseManager.movieContext!.Ratings.Where(a => a.Id == id).First();
        }

        /// <summary>
        /// Edit rating in the database
        /// </summary>
        /// <param name="a"></param>
        public static void Update(Rating a)
        {
            Rating rating = DatabaseManager.movieContext!.Ratings.Where(a => a.Id == a.Id).First();
            rating.Name = a.Name ?? rating.Name;
            rating.Description = a.Description ?? rating.Description;
            if (a.Stars != null)
            {
                rating.Stars = a.Stars;
            }
            else rating.Stars = rating.Stars;
            if (a.Movie != null)
            {
                rating.Movie = a.Movie;
            }
            else rating.Movie = rating.Movie;
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Delete rating from the database
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Rating rating = DatabaseManager.movieContext!.Ratings.Where(x => x.Id == id).First();
            DatabaseManager.movieContext.Remove(rating);
            DatabaseManager.movieContext.SaveChanges();
        }
    }
}
