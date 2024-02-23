using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using philipsgodtepose.Models;
using philipsgodtepose.Repositories;

namespace philipsgodtepose.Views
{
    public class RateMovies
    {
        public static void Rate()
        {

            Console.WriteLine("Which movie would you like to rate?\nPress 1: to see all listings\nPress 2: to search");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    MovieRepository.GetAll().ForEach(x =>
                    { Console.WriteLine(x.ToString()); });
                    break;
                case "2":
                    SearchMovies.Search();
                    break;
            }

            Console.WriteLine("\nNumber of movie you want to rate?:\n");
            int movieById = 0;
            try
            {
            movieById = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex) { return; }

            bool checkById = true;
            while (checkById)
            {
                try
                {
                    MovieRepository.GetById(movieById);
                }
                catch (Exception ex) { }
                finally
                {
                    checkById = false;
                }
            }

            string userName = "";

            Console.WriteLine("Your name:\n\n");
            userName = Console.ReadLine();
            if (userName == null)
                return;

            Console.WriteLine("Write your review here: ");
            string description = Console.ReadLine();
            
            Console.WriteLine("Rate movie 1-5 stars");

            int stars = 0;
            Console.WriteLine("How many stars would you like to rate this movie with?");
            try
            {
            stars = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception ex) { return; }
            if (stars == 0)
                return;

            Movie movieToRate = MovieRepository.GetById(movieById);

            Rating rating1 = new Rating(userName, description, stars, movieToRate);

            RatingRepository.Add(rating1);
        }
    }
}