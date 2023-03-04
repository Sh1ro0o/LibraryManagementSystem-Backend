using System.ComponentModel.DataAnnotations;

namespace Library_Project.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
