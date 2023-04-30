using Library_Project.Models;

namespace Library_Project.Dto
{
    public class BookDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Publisher { get; set; }
        public List<Author> Authors { get; set; }
    }
}
