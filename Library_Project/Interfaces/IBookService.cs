using Library_Project.Dto;
using Library_Project.Models;

namespace Library_Project.Interfaces
{
    public interface IBookService
    {
        List<BookDto> GetBooks();
        BookDto GetBook(int id);
        bool BookExists(int id);
    }
}
