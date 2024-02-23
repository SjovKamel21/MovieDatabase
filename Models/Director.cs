using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Models
{
    public class Director
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; private set; }

        public Director() { }

        public Director(string name)
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