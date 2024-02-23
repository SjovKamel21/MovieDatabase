// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using philipsgodtepose;
using philipsgodtepose.Models;
using philipsgodtepose.Repositories;
using philipsgodtepose.Views;

bool init = DatabaseManager.Init();

while (init)
{
    Console.WriteLine("Press key to select... \n1: View listing\n2: Add listing \n3: Remove listing \n4: Search listing \n5: Rate listing \n");
    switch (Console.ReadLine())
    {
        case "1":
            {
                Console.Clear();
                ViewMovies.Movies();
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            break;
        case "2":
            {
                Console.Clear();
                CreateMovies.Create();
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            break;
        case "3":
            {
                Console.Clear();
                DeleteMovies.Delete();
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            break;
        case "4":
            {
                Console.Clear();
                SearchMovies.Search();
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            break;
        case "5":
            {
                Console.Clear();
                RateMovies.Rate();
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            break;
    }
    Console.Clear();
}
/*
Director director1 = new Director(1, "Homo");
List<Actor> actors = new List<Actor> { new Actor(1, "Philip"), new Actor(2, "Abe") };

ActorRepository.AddBulk(actors);

Movie movie1 = new Movie(1, "LorteLandIAfrika", actors, director1);

MovieRepository.Add(movie1);

ActorRepository.GetAll().ForEach(x =>
{
    Console.WriteLine(x.ToString());
});
Console.WriteLine("");
MovieRepository.GetAll().ForEach(x =>
{ Console.WriteLine(x.ToString()); });

var options = new DbContextOptionsBuilder<MovieContext>()
    .UseSqlite("Filename=../../../MyLibrary.db")
    .Options;

using var db = new MovieContext(options);

//db.Database.EnsureCreated();
*/