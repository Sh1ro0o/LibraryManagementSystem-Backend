using Library_Project.Models;

namespace Library_Project.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int userId);
        User GetUser(string username);
        bool UserExists(int userId);
        bool UserExists(string username);
    }
}
