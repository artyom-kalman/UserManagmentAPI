using UserManagmentAPI.Interfaces;
using UserManagmentAPI.Models;

namespace UserManagmentAPI.Repository
{
    public class UserGroupRepository : IUserGroup
    {
        private VkTestDbContext _dbContext;

        public UserGroupRepository(VkTestDbContext context) 
        {
            _dbContext = context;
        }

        public ICollection<UserGroup> GetUserGroups() 
        {
            return _dbContext.UserGroups.OrderBy(g => g.Id).ToList();
        }

        public UserGroup GetUserGroup(int id)
        {
            return _dbContext.UserGroups.Where(g => g.Id == id).FirstOrDefault();
        }
    }
}
