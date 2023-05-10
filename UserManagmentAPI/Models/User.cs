using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UserManagmentAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public int? UserGroupId { get; set; }

    public int? UserStateId { get; set; }

    public virtual UserGroup UserGroup { get; set; }

    public virtual UserState UserState { get; set; }
}
