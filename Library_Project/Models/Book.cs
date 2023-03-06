using System.ComponentModel.DataAnnotations;

namespace Library_Project.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Publisher { get; set; }

        public IList<BookAuthor> BookAuthors { get; set; }
    }
}
