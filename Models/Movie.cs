using philipsgodtepose.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace philipsgodtepose.Models
{
    public class Movie
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Director> Director { get; set; }
        public Genre Genre { get; set; }
        public List<Rating> Ratings { get; set; }

        public Movie() { }

        public Movie(string name, List<Actor> actors, List<Director> director, Genre genre)
        {
            Name = name;
            Actors = actors;
            Director = director;
            Genre = genre;
        }

        public override string ToString()
        {
            string output;
            output = "Number: "; output += Id.ToString();
            output += "\nName: "; output += Name.ToString();
            output += "\nActors: ";
            Actors.ForEach(x =>
            {
                output += x.ToString();
                output += ", ";
            });
            output = output.Remove(output.Length - 2, 2);

            output += "\nDirector: ";
            //Director.ForEach(x => { output += x.ToString(); });
            if (Director != null)
            {
                output += string.Join("", Director.Select(director => director.ToString()));
            }
            output += "\nGenre: ";
            if (Genre != null)
            {
                output += Genre.ToString();
                output += "\n";
            }

            RatingRepository.GetAll();
            Ratings?.ForEach(x =>
            {
                output += x.ToString();
                output += ", \n";
            });

            if (Ratings != null)
            {
                output = output.Remove(output.Length - 2, 2);
                output += "\n";
            }

            if (Ratings != null)
            {
                double averageStars = DatabaseManager.movieContext!.Ratings
                    .Where(a => a.Stars.HasValue) 
                    .Select(a => a.Stars.Value)   
                    .Average();                   
                output += "Average rating: ";
                output += averageStars;
            }

            return output;
        }
    }
}
