﻿using BookStore.BookOperations.CreateBook;
using BookStore.DbOperations;


    
    namespace BookStore.BookOperations.DeleteBook
{

    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;

        // Silinecek kitabın id bilgisi
        public int BookId { get; set; }

        
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        
        public void Handle()
        {
            

           
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);

          
            if (book is null)
            {
                throw new InvalidOperationException("Book doesn't exist.");
            }

            _dbContext.Books.Remove(book);

       
            _dbContext.SaveChanges();
        }
    }

}
