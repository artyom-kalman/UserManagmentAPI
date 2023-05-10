using System;
using System.Collections.Generic;

namespace UserManagmentAPI.Models;

public partial class UserGroup
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string? Description { get; set; }
}
