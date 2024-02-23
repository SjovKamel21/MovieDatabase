using philipsgodtepose.Models;
using philipsgodtepose.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Views
{
    public class ViewMovies
    {
        public static void Movies()
        {
            while (true)
            {
                Console.Clear();
                //Director director1 = new Director("Homo");
                //List<Actor> actors = new List<Actor> { new Actor("Philip"), new Actor("Abe") };
                //Movie movie1 = new Movie("LorteLandIAfrika", actors, director1);
                //MovieRepository.Add(movie1);
                Console.WriteLine("1: View movies\n2: View actors\n3: View directors\n");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.Clear();
                            MovieRepository.GetAll().ForEach(x =>
                            { Console.WriteLine(x.ToString()); });
                            return;
                        }
                    case "2":
                        {
                            Console.Clear();
                            ActorRepository.GetAll().ForEach(x =>
                            { Console.WriteLine(x.ToStringId()); });
                            return;
                        }
                    case "3":
                        {
                            Console.Clear();
                            DirectorRepository.GetAll().ForEach(x =>
                            { Console.WriteLine(x.ToStringId()); });
                            return;
                        }
                }
            }
        }
    }
}