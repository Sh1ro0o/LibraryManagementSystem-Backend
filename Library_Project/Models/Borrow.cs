using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Project.Models
{
    public class Borrow
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateBorrowed { get; set; }

        public DateTime DateReturned { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
