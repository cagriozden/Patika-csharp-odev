
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.DbOperations;

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {

        using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {

            if (context.Books.Any())
            {
                return;
            }


            context.Books.AddRange(
                new Book
                   {
                   
                    Id = 1,
                    Title = "The Alchemist",
                    GenreId = 1,
                    PageCount = 208,
                    PublishDate = new DateTime(2023, 09, 05)
                },
                new Book
                {
                    //  Id = 2,
                    Id = 2,
                    Title = "To Kill a Mockingbird",
                    GenreId = 1,
                    PageCount = 324,
                    PublishDate = new DateTime(2023, 08, 20)
                },
                new Book
                {
                    //  Id = 3,
                    Id = 3,
                    Title = "1984",
                    GenreId = 3,
                    PageCount = 328,
                    PublishDate = new DateTime(2023, 11, 15)
                },
                new Book
                {
                    Id = 4,
                    Title = "The Hitchhiker's Guide to the Galaxy",
                    GenreId = 2,
                    PageCount = 256,
                    PublishDate = new DateTime(2023, 10, 10)
                },
                new Book
                {
                    Id = 5,
                    Title = "Brave New World",
                    GenreId = 3,
                    PageCount = 288,
                    PublishDate = new DateTime(2023, 09, 28)
                },
                new Book
                {
                    Id = 6,
                    Title = "Pride and Prejudice",
                    GenreId = 1,
                    PageCount = 432,
                    PublishDate = new DateTime(2023, 10, 05)
                }
            );


            context.SaveChanges();
        }
    }
}
