using System;
using System.Collections.Generic;
namespace medical_Center.Model;


public partial class User
{
    public int IdUser { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Login { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string Phone{ get; set; } = null!;
    public DateOnly Birthday { get; set; }

    public int role_idrole { get; set; }
}
