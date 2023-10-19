using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.DBOperations
{
    [Route("api/[controller]")]
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Books.Any())
                {
                    return;   // Data was already seeded
                }
                context.Genres.AddRange(

                    new Genre
                    {
                        Name = "TrueCrime"
                    },

                    new Genre
                    {
                        Name = "ScienceFiction"
                    },

                    new Genre
                    {
                        Name = "PersonalGrowth"
                    }
                    );
                context.Authors.AddRange(

                    new Author
                    {
                        Name = " Paulo",
                        Surname= "Coelho",
                        BirthDate= new DateTime(1998, 05, 21)
                    },
                    new Author
                    {
                        Name = "Harper ",
                        Surname = "Lee",
                        BirthDate = new DateTime(1998, 05, 21)
                    },
                    new Author
                    {
                        Name = "George ",
                        Surname = "Orwell",
                        BirthDate = new DateTime(1998,05,21)
                    }
                    ) ;
                context.Books.AddRange(
                new Book
                {
                   //Id=1,
                   Title= "The Alchemist",
                   GenreId=1,
                   PageCount = 208,
                   PublishDate = new DateTime(2023, 09, 05),
                   AuthorId = 1
                },
                new Book
                {
                   //Id=2,
                   Title= "To Kill a Mockingbird",
                   GenreId=2,
                   PageCount = 324,
                   PublishDate = new DateTime(2023, 08, 20),
                   AuthorId = 2
                },
                new Book
                {
                   //Id=3,
                   Title= "1984",
                   GenreId=3,
                   PageCount=386,
                   PublishDate= new DateTime(2004,12,06),
                   AuthorId = 3
                }
            );

                context.SaveChanges();
            }
        }
    }
}

