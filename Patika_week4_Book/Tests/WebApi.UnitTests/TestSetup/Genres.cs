using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
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
        }
    }
}

