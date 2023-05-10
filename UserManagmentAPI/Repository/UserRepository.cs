using System.Text.RegularExpressions;
using UserManagmentAPI.Interfaces;
using UserManagmentAPI.Models;

namespace UserManagmentAPI.Repository
{
    public class UserRepository : IUser
    {
        private readonly VkTestDbContext _dbContext;
        public UserRepository(VkTestDbContext context)
        {
            _dbContext = context;
        }

        public ICollection<User> GetUsers()
        {
            return _dbContext.Users.OrderBy(u => u.Id).ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            return _dbContext.Users.Where(u => u.Login == username).FirstOrDefault();
        }

        public bool UserExists(int id)
        {
            return _dbContext.Users.Any(u => u.Id == id);
        }

        public bool CreateUser(User user)
        {
            // Проверка, существует ли пользователь с ролью Admin
            if (user.UserGroupId == _dbContext.UserGroups.Where(s => s.Code == "Admin").First().Id)
            {
                if (_dbContext.Users.Any(u => u.UserGroup.Code == "Admin"))
                    return false;
            }

            // Присваивание статуса "Active"
            user.UserStateId = _dbContext.UserStates.Where(s => s.Code == "Active").First().Id;
            _dbContext.Add(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool DeleteUser(User user)
        {
            // Изменение статуса на "Blocked"
            user.UserStateId = _dbContext.UserStates.Where(s => s.Code == "Blocked").First().Id;
            _dbContext.Update(user);
            return Save();
        }
    }
}
