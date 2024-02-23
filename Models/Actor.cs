using philipsgodtepose.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Models
{
    public class Actor
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }

        public Actor() { }

        public Actor(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
        public string ToStringId()
        {
            return $"Id({Id}): {Name}";
        }
    }
}
