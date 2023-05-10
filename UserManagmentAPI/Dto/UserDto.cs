using UserManagmentAPI.Models;

namespace UserManagmentAPI.Dto
{
    public class UserDto
    {

        public string? Login { get; set; }

        public string? Password { get; set; }

        public int? UserGroupId { get; set; }

        //public int? UserStateId { get; set; }

        //public virtual UserGroup? UserGroup { get; set; }

        //public virtual UserState? UserState { get; set; }
    }
}
