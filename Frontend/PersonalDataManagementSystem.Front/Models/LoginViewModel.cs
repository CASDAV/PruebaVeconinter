using System;
using System.ComponentModel.DataAnnotations;

namespace PersonalDataManagementSystem.Front.Models;

public class LoginViewModel
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
