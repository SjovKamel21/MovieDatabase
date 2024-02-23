using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using philipsgodtepose.Models;
using philipsgodtepose.Repositories;

namespace philipsgodtepose.Views
{
    public class SearchMovies
    {
        public static void Search()
        {
            Console.WriteLine("Search:\n\n");
            string input = Console.ReadLine();
            var SearchResult = DatabaseManager.movieContext!.Movies
            .Where(a => a.Name.ToLower().Contains(input!.ToLower()))
            .Select(a => a.Id)
            .ToList();

            if (SearchResult.Any())
            {
                foreach (var movieId in SearchResult) { Console.WriteLine(MovieRepository.GetById(movieId)); }
            }
        }
    }
}
