using System.Diagnostics.Metrics;
using Library_Project.Data;
using Library_Project.Models;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace Library_Project
{
    public class Seed
    {
        private readonly LibraryDbContext dataContext;
        public Seed(LibraryDbContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.BookAuthors.Any())
            {
                var bookAuthors = new List<BookAuthor>()
                {
                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Title = "Pokemon",
                            Category = "Horror",
                            Publisher = "Harvey Norman"
                        },
                        Author = new Author()
                        {
                            FirstName = "Jack",
                            LastName = "London"
                        }
                    },
                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Title = "Viking Saga",
                            Category = "History",
                            Publisher = "History Museum"
                        },
                        Author = new Author()
                        {
                            FirstName = "Tom",
                            LastName = "Slokwe"
                        }
                    },
                    new BookAuthor()
                    {
                        Book = new Book()
                        {
                            Title = "Mario Kart 8 Tutorial",
                            Category = "Fun",
                            Publisher = "Nintendo"
                        },
                        Author = new Author()
                        {
                            FirstName = "Fujusuhi",
                            LastName = "Miyamoto"
                        }
                    }
                };
                dataContext.BookAuthors.AddRange(bookAuthors);
                dataContext.SaveChanges();
            }
        }
    }
}
