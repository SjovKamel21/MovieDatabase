using philipsgodtepose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace philipsgodtepose.Repositories
{
    public static class ActorRepository
    {
        private static List<Actor> _actors = new List<Actor>();

        /// <summary>
        /// Add actor to the database
        /// </summary>
        /// <param name="a"></param>
        public static void Add(Actor a)
        {
            DatabaseManager.movieContext!.Add(a);
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Add multiple actors to the database
        /// </summary>
        /// <param name="a"></param>
        public static void AddBulk(List<Actor> a)
        {
            DatabaseManager.movieContext!.AddRange(a);
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Get all actors from the database
        /// </summary>
        /// <returns>All actors from the database</returns>
        public static List<Actor> GetAll()
        {
            return DatabaseManager.movieContext!.Actors.ToList();
        }

        /// <summary>
        /// Get an instance of actor by id
        /// </summary>
        /// <param name="id">The id of the actor to get</param>
        /// <returns>The instance of Actor</returns>
        public static Actor? GetById(int id)
        {
            //return _actors.Find(a => a.Id == id);
            return DatabaseManager.movieContext!.Actors.Where(a => a.Id == id).First();
        }

        /// <summary>
        /// Edit an actor in the database by id
        /// </summary>
        /// <param name="a"></param>
        public static void Update(Actor a) 
        {
            Actor actor = DatabaseManager.movieContext!.Actors.Where(a => a.Id == a.Id).First();
            actor.Name = a.Name ?? actor.Name;
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Delete an actor from the database
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Actor actor = DatabaseManager.movieContext!.Actors.Where(x => x.Id == id).First();
            DatabaseManager.movieContext.Remove(actor);
            DatabaseManager.movieContext.SaveChanges();
        }

        /// <summary>
        /// Create new actor if given actor is not found
        /// </summary>
        /// <param name="_actor"></param>
        /// <returns>returns actor if actor is not null</returns>
        public static Actor FindOrCreate(string _actor)
        {
            try
            {
                Actor actor = DatabaseManager.movieContext!.Actors.Where(a => a.Name == _actor).First();
                if (actor != null)
                {
                    return actor;
                }
            }
            catch (Exception ex) { }

            Actor a = new Actor(_actor);
            Actor ac = DatabaseManager.movieContext!.Actors.Add(a).Entity;
            DatabaseManager.movieContext.SaveChanges();
            return ac!;
        }
    }
}
