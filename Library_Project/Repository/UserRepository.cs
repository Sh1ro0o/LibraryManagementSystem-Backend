using Library_Project.Data;
using Library_Project.Interfaces;
using Library_Project.Models;

namespace Library_Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _context;
        public UserRepository(LibraryDbContext context)
        {
            _context = context;
        }

        //get user by id
        public User GetUser(int userId)
        {
            User user = _context.Users.Where(u => u.Id == userId).FirstOrDefault()!;

            return user;
        }

        //get user by username
        public User GetUser(string username)
        {
            //! at the end tells the compiler this won't be null, because before we call get users we call UserExists and if true it will call this function
            User user = _context.Users.Where(u => u.Username == username).FirstOrDefault()!;

            return user;
        }

        //ICollection cannot be edited but can only be read 
        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Id).ToList();
        }

        //check if user exists by id
        public bool UserExists(int userId)
        {
            return _context.Users.Any(u => u.Id == userId);
        }

        //check if user exists by string
        public bool UserExists(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
    }
}
