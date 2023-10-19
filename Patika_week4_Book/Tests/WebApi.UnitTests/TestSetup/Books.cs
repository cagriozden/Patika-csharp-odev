using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                
                    Title = "The Alchemist",
                    GenreId = 1,
                    PageCount = 208,
                    PublishDate = new DateTime(2023, 09, 05),
                    AuthorId = 1
                },
                new Book
                {
                    
                    Title = "To Kill a Mockingbird",
                    GenreId = 2,
                    PageCount = 324,
                    PublishDate = new DateTime(2023, 08, 20),
                    AuthorId = 2
                },
                new Book
                {
                   
                    Title = "1984",
                    GenreId = 3,
                    PageCount = 386,
                    PublishDate = new DateTime(2004, 12, 06),
                    AuthorId = 3
                }
            );
        }
    }
}

