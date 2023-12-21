using System;
using System.Collections.Generic;

namespace api_rsholdings.Models;

public partial class Administrator
{
    public string AdminId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Password { get; set; }

    public string? ResetKey { get; set; }
}
