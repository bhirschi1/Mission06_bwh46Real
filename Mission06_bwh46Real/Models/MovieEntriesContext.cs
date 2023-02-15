using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_bwh46.Models
{
    public class MovieEntriesContext : DbContext
    {
        //Constructor
        public MovieEntriesContext(DbContextOptions<MovieEntriesContext> options) : base(options)
        {

        }

        public DbSet<MovieEntry> Entries { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Importing, or seeding, 3 movies of my own choosing upon the creation of the database
            mb.Entity<MovieEntry>().HasData(
                new MovieEntry
                {
                    entryId = 1,
                    category = "Comedy",
                    title = "Get Smart",
                    year = 2008,
                    director = "Peter Segal",
                    rating = "PG-13",
                },

                new MovieEntry
                {
                    entryId = 2,
                    category = "Action",
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
                    category = "Romance/Comedy",
                    title = "Crazy, Stupid, Love",
                    year = 2011,
                    director = "Glenn Ficarra, John Requa",
                    rating = "PG-13",
                }
                );

    }

    }
}
