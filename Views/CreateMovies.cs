using philipsgodtepose.Models;
using philipsgodtepose.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Views
{
    public class CreateMovies
    {
        public static void Create()
        {
            Console.WriteLine("Director name: ");
            string directorName = Console.ReadLine();
            Console.WriteLine("Genre name: ");
            string genreName = Console.ReadLine();

            bool loop = true;
            List<Actor> actors = new List<Actor>();
            Console.WriteLine("Press 0 to exit actor creation");
            while (loop)
            {
                Console.WriteLine("Actor name: ");
                string s = Console.ReadLine();
                if (s != "0")
                {
                    if (s != "")
                        //actors.Add(new Actor(s));
                        actors.Add(ActorRepository.FindOrCreate(s));
                    else
                        Console.WriteLine("Actor name is empty");
                }
                else break;
            }

            Console.WriteLine("Movie name: ");
            string movieName = Console.ReadLine();

            if (directorName == "")
            {
                Console.WriteLine("Error! Director name is empty");
                return;
            }

            if (genreName == "")
            {
                Console.WriteLine("Error! Genre name is empty");
                return;
            }

            if (movieName == "")
            {
                Console.WriteLine("Error! Movie name is empty");
                return;
            }

            List<Director> director1 = new List<Director>();
            
            director1.Add(DirectorRepository.FindOrCreate(directorName));
            Genre genre = GenreRepository.FindOrCreate(genreName);
            Movie movie1 = new Movie(movieName, actors, director1, genre);

            MovieRepository.Add(movie1);
        }
    }
}
