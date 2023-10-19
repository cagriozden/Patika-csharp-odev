using System;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Entities;

namespace MovieStoreApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                    return;

                context.Actors.AddRange(

                    new Actor
                    {
                        Name = "Leonardo",
                        Surname = "DiCaprio",
                        Id = 1
                    },
                    new Actor
                    {
                        Name = "Tom",
                        Surname = "Hanks",
                        Id = 2
                    },
                    new Actor
                    {
                        Name = "Meryl",
                        Surname = "Streep",
                        Id = 3
                    }
                    );
                context.Directors.AddRange(

                    new Director
                    {
                        Name = "Christopher",
                        Surname = "Nolan",
                        Id = 1
                    },
                    new Director
                    {
                        Name = "Quentin",
                        Surname = "Tarantino",
                        Id = 2
                    },
                    new Director
                    {
                        Name = "Steven",
                        Surname = "Spielberg",
                        Id = 3
                    }
                    );
                context.Genres.AddRange(

                    new Genre
                    {
                        Name = "Drama"
                    },
                    new Genre
                    {
                        Name = "Action"
                    },
                    new Genre
                    {
                        Name = "Comedy"
                    }
                    );
                context.SaveChanges();
                context.Movies.AddRange(

                    new Movie
                    {
                        Name = "Inception",
                        Year = 2010,
                        Actors = context.Actors.Where(c => new[] { 1, 2 }.Contains(c.Id)).ToList(),
                        DirectorId = 1,
                        GenreId = 1,
                        Price = 50
                    },
                    new Movie
                    {
                        Name = "Pulp Fiction",
                        Year = 1994,
                        Actors = context.Actors.Where(c => new[] { 2, 3 }.Contains(c.Id)).ToList(),
                        DirectorId = 2,
                        GenreId = 2,
                        Price = 45
                    },
                    new Movie
                    {
                        Name = "Forrest Gump",
                        Year = 1994,
                        Actors = context.Actors.Where(c => new[] { 1, 3 }.Contains(c.Id)).ToList(),
                        DirectorId = 3,
                        GenreId = 3,
                        Price = 55
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
