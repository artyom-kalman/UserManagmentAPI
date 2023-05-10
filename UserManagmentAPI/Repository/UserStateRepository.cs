using System.Runtime.InteropServices.ObjectiveC;
using UserManagmentAPI.Interfaces;
using UserManagmentAPI.Models;

namespace UserManagmentAPI.Repository
{
    public class UserStateRepository : IUserState
    {
        private VkTestDbContext _dbContext;

        public UserStateRepository(VkTestDbContext context)
        {
            _dbContext = context;
        }

        public UserState GetUserState(int id)
        {
            return _dbContext.UserStates.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<UserState> GetUserStates()
        {
            return _dbContext.UserStates.OrderBy(s => s.Id).ToList();
        }
    }
}
