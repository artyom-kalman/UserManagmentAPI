using UserManagmentAPI.Models;

namespace UserManagmentAPI.Interfaces
{
    public interface IUser
    {
        ICollection<User> GetUsers();
        User GetUserById(int id);
        User GetUserByUsername(string username);
        bool UserExists(int id);
        bool CreateUser(User user);
        bool DeleteUser(User user);
        bool Save();
    }
}
