using AutoMapper;
using Library_Project.Data;
using Library_Project.Dto;
using Library_Project.Interfaces;
using Library_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace Library_Project.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        public BookService(LibraryDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public BookDto GetBook(int id)
        {
            var book = _context.Books.Where(book => book.Id == id)
                                      .Include(book => book.Authors)
                                      .FirstOrDefault()!;

            var bookAuthors = _context.BookAuthors.Where(bookAuthor => bookAuthor.BookId == id).ToList();
            var author = _context.Authors.ToList();

            List<Author> authorsToAdd = new List<Author>(); 

            if(bookAuthors != null)
            {
                foreach (BookAuthor bookAuthor in bookAuthors)
                {
                    var tempAuthor = author.Where(a => a.Id == bookAuthor.AuthorId).FirstOrDefault();
                    if (tempAuthor != null)
                        authorsToAdd.Add(tempAuthor); //add author to list
                }
            }

            //if we added any authors we assign them to Book
            if(authorsToAdd.Count > 0) 
            {
                book.Authors = authorsToAdd;
            }

            //mapping
            BookDto response = _mapper.Map<Book, BookDto>(book);

            return response;
        }

        public List<BookDto> GetBooks()
        {
            var books = _context.Books.ToList();

            if(books.Count == 0)
            {
                return _mapper.Map<List<Book>, List<BookDto>>(books); //we return empty List since no books were found
            }

            foreach (Book book in books)
            {
                var bookAuthors = _context.BookAuthors.Where(bookAuthor => bookAuthor.BookId == book.Id).ToList();
                var author = _context.Authors.ToList();

                List<Author> authorsToAdd = new List<Author>();

                if (bookAuthors != null)
                {
                    foreach (BookAuthor bookAuthor in bookAuthors)
                    {
                        var tempAuthor = author.Where(a => a.Id == bookAuthor.AuthorId).FirstOrDefault();
                        if (tempAuthor != null)
                            authorsToAdd.Add(tempAuthor); //add author to list
                    }
                }

                //if we added any authors we assign them to Book
                if (authorsToAdd.Count > 0)
                {
                    book.Authors = authorsToAdd;
                }
            }

            //mapping
            List<BookDto> response = _mapper.Map<List<Book>, List<BookDto>>(books);

            return response;
        }

        public bool BookExists(int id)
        {
            return _context.Books.Any(b => b.Id == id);
        }
    }
}
