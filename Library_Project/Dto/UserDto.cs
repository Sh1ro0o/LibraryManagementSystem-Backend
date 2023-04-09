using System.ComponentModel.DataAnnotations;

namespace Library_Project.Dto
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
