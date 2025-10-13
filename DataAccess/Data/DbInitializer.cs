using DataAccess.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public static class DbInitializer
    {
        public static void SeedMovies(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new[]
            {
                new Movie()
                {
                    Id = 1,
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    Overview = "An epic fantasy adventure based on J.R.R. Tolkien's novel.",
                    Rating = 8.8,
                    Budget = 93000000,
                    ReleaseDate = new DateTime(2001, 12, 19),
                    PosterUrl = "https://m.media-amazon.com/images/I/51Qvs9i5a%2BL._AC_.jpg",
                },
                new Movie()
                {
                    Id = 2,
                    Title = "The Hobbit: An Unexpected Journey",
                    Overview = "Bilbo Baggins joins Gandalf and dwarves on a quest to reclaim Erebor.",
                    Rating = 7.8,
                    Budget = 180000000,
                    ReleaseDate = new DateTime(2012, 12, 14),
                    PosterUrl = "https://m.media-amazon.com/images/I/81t2CVWEsUL._AC_SL1500_.jpg",
                },
                new Movie()
                {
                    Id = 3,
                    Title = "Harry Potter and the Sorcerer's Stone",
                    Overview = "The beginning of Harry Potter's magical journey at Hogwarts.",
                    Rating = 7.6,
                    Budget = 125000000,
                    ReleaseDate = new DateTime(2001, 11, 16),
                    PosterUrl = "https://m.media-amazon.com/images/I/51UoqRAxwEL._AC_.jpg",
                }
            });
        }

        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(new[]
            {
                new Genre() { Id = 1, Name = "Fantasy" },
                new Genre() { Id = 2, Name = "Adventure" },
                new Genre() { Id = 3, Name = "Action" },
                new Genre() { Id = 4, Name = "Drama" }
            });
        }

        public static void SeedActors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(new[]
            {
                new Actor() { Id = 1, Name = "Elijah Wood" },
                new Actor() { Id = 2, Name = "Ian McKellen" },
                new Actor() { Id = 3, Name = "Martin Freeman" },
                new Actor() { Id = 4, Name = "Daniel Radcliffe" },
                new Actor() { Id = 5, Name = "Emma Watson" }
            });
        }

        public static void SeedMovieActors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieActor>().HasData(new[]
            {
                new MovieActor() { Id = 1, MovieId = 1, ActorId = 1, CharacterName = "Frodo Baggins" },
                new MovieActor() { Id = 2, MovieId = 1, ActorId = 2, CharacterName = "Gandalf" },
                new MovieActor() { Id = 3, MovieId = 2, ActorId = 3, CharacterName = "Bilbo Baggins" },
                new MovieActor() { Id = 4, MovieId = 3, ActorId = 4, CharacterName = "Harry Potter" },
                new MovieActor() { Id = 5, MovieId = 3, ActorId = 5, CharacterName = "Hermione Granger" }
            });
        }
    }
}
