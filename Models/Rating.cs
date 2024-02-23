using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Stars { get; set; }
        public Movie Movie { get; set; }

        public Rating() { }
        public Rating(string name, string description, int stars, Movie movie)
        {
            Name = name;
            Description = description;
            Stars = stars;
            Movie = movie;
        }
        public override string ToString()
        {
            return $"Rating: {Name}, {Description}, Stars: {Stars}";
        }
    }
}
