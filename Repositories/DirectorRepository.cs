using philipsgodtepose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Repositories
{
    public static class DirectorRepository
    {
        private static List<Director> _directors = new List<Director>();

        /// <summary>
        /// Add director to the database
        /// </summary>
        /// <param name="a"></param>
        public static void Add(Director a)
        {
            DatabaseManager.movieContext!.Directors.Add(a);
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Get all directors from the database
        /// </summary>
        /// <returns>returns directors to list</returns>
        public static List<Director> GetAll()
        {
            return DatabaseManager.movieContext!.Directors.ToList();
        }

        /// <summary>
        /// Get director from database by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>returns director</returns>
        public static Director? GetById(int id)
        {
            return DatabaseManager.movieContext!.Directors.Where(a => a.Id == id).First();
        }

        /// <summary>
        /// Edit director in database
        /// </summary>
        /// <param name="a"></param>
        public static void Update(Director a)
        {
            Director director = DatabaseManager.movieContext!.Directors.Where(a => a.Id == a.Id).First();
            director.Name = a.Name ?? director.Name;
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Delete director in the database
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Director director = DatabaseManager.movieContext!.Directors.Where(x => x.Id == id).First();
            DatabaseManager.movieContext.Directors.Remove(director);
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Create new director if given director is not found
        /// </summary>
        /// <param name="_director"></param>
        /// <returns>returns director if director is not null</returns>
        public static Director FindOrCreate(string _director)
        {
            try
            {
                Director director = DatabaseManager.movieContext!.Directors.Where(a => a.Name == _director).First();
                if (director != null)
                {
                    return director;
                }
            }
            catch (Exception ex) { }

            Director a = new Director(_director);
            Director ac = DatabaseManager.movieContext!.Directors.Add(a).Entity;
            DatabaseManager.movieContext.SaveChanges();
            return ac!;
        }
    }
}
