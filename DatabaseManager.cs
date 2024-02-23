using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace philipsgodtepose
{
    public static class DatabaseManager
    {
        public static MovieContext? movieContext;

        public static bool Init()
        {
            try
            {
                string filePath = "Filename=../../../PhilipsLilleLibrary.db";
            var options = new DbContextOptionsBuilder<MovieContext>()
            .UseSqlite(filePath)
            .Options;

                movieContext = new MovieContext(options);

                // Check if db file exists
                if (!File.Exists(filePath))
                {
                    // Ensure db is created
                    movieContext.Database.EnsureCreated();

                }

                return true;
            } catch (Exception ex)
            {
                //Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
