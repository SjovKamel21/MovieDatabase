using Microsoft.EntityFrameworkCore;
using philipsgodtepose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Repositories
{
    public static class GenreRepository
    {
        private static List<Genre> _genres = new List<Genre>();

        /// <summary>
        /// Add genre to database
        /// </summary>
        /// <param name="a"></param>
        public static void Add(Genre a)
        {
            DatabaseManager.movieContext!.Genres.Add(a);
            DatabaseManager.movieContext!.SaveChanges();
        }

        /// <summary>
        /// Get all genres from database
        /// </summary>
        /// <returns>returns all genres</returns>
        public static List<Genre> GetAll()
        {
            return DatabaseManager.movieContext!.Genres.ToList();
        }

        /// <summary>
        /// Get genre by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns genre</returns>
        public static Genre? GetById(int id)
        {
            return DatabaseManager.movieContext!.Genres.Where(a => a.Id == id).First();
        }

        /// <summary>
        /// Edit a genre in the database
        /// </summary>
        /// <param name="a"></param>
        public static void Update(Movie a)
        {
            Genre genre = DatabaseManager.movieContext!.Genres.Where(a => a.Id == a.Id).First();
            genre.Name = a.Name ?? genre.Name;
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Delete a genre from database
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Genre genre = DatabaseManager.movieContext!.Genres.Where(x => x.Id == id).First();
            DatabaseManager.movieContext.Remove(genre);
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Create new genre if given genre is not found
        /// </summary>
        /// <param name="_genre"></param>
        /// <returns>returns genre if genre is not null</returns>
        public static Genre FindOrCreate(string _genre)
        {
            try
            {
                Genre genre = DatabaseManager.movieContext!.Genres.Where(a => a.Name == _genre).First();
                if (genre != null)
                {
                    return genre;
                }
            }
            catch (Exception ex) { }

            Genre a = new Genre(_genre);
            Genre ac = DatabaseManager.movieContext!.Genres.Add(a).Entity;
            DatabaseManager.movieContext.SaveChanges();
            return ac!;
        }
    }
}
