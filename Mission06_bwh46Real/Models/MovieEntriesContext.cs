using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Mission06_bwh46Real.Models;

namespace Mission06_bwh46.Models
{
    public class MovieEntriesContext : DbContext
    {
        //Constructor
        public MovieEntriesContext(DbContextOptions<MovieEntriesContext> options) : base(options)
        {

        }
        //must add the DbSet<Category> because we added that table
        public DbSet<MovieEntry> Entries { get; set; }
        public DbSet<Category> Category { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            // must create the category table first
            // categories are from the ones listed in the spreadsheet from the excel spreadsheet
            // the 2 vars are categoryId and catName as indicated in the Category.cs file

            mb.Entity<Category>().HasData(
                new Category { categoryId = 1, catName = "Action/Adventure" },
                new Category { categoryId = 2, catName = "Comedy" },
                new Category { categoryId = 3, catName = "Drama" },
                new Category { categoryId = 4, catName = "Family" },
                new Category { categoryId = 5, catName = "Horror/Suspense" },
                new Category { categoryId = 6, catName = "Miscellaneous" },
                new Category { categoryId = 7, catName = "Television" },
                new Category { categoryId = 8, catName = "VHS" }
                );

            // had to change the category to categoryId in concurrence with the Category model
            //Importing, or seeding, 3 movies of my own choosing upon the creation of the database
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    entryId = 1,
                    categoryId = 2,
                    title = "Get Smart",
                    year = 2008,
                    director = "Peter Segal",
                    rating = "PG-13",
                },

                new MovieEntry
                {
                    entryId = 2,
                    categoryId = 3,
                    title = "Creed",
                    year = 2015,
                    director = "Ryan Coogler",
                    rating = "PG-13",
                    edited = false,
                    notes = "There is a sequel, and a third movie soon!",
                },

                new MovieEntry
                {
                    entryId = 3,
                    categoryId = 2,
                    title = "Crazy, Stupid, Love",
                    year = 2011,
                    director = "Glenn Ficarra, John Requa",
                    rating = "PG-13",
                }
                );

    }

    }
}
