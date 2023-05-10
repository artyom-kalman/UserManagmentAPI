using UserManagmentAPI.Models;

namespace UserManagmentAPI.Interfaces
{
    public interface IUserGroup
    {
        ICollection<UserGroup> GetUserGroups();
        UserGroup GetUserGroup(int id);
    }
}
