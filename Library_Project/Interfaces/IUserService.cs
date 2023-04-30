using Library_Project.Models;

namespace Library_Project.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUser(int userId);
        User GetUser(string username);
        bool UserExists(int userId);
        bool UserExists(string username);
    }
}
