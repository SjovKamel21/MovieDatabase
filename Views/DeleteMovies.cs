using philipsgodtepose.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose.Views
{
    internal class DeleteMovies
    {
        public static void Delete()
        {
            MovieRepository.GetAll().ForEach(x => 
            { Console.WriteLine(x.ToString()); });
            Console.WriteLine("Number of movie you want to delete: ");
            try
            {
                MovieRepository.Delete(Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception ex) { return; }
        }
    }
}
