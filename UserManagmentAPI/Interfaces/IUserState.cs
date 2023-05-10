using UserManagmentAPI.Models;

namespace UserManagmentAPI.Interfaces
{
    public interface IUserState
    {
        ICollection<UserState> GetUserStates();
        UserState GetUserState(int id);
    }
}
