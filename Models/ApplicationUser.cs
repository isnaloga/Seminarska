using Microsoft.AspNetCore.Identity;

namespace IS_nal.Models;

public class ApplicationUser : IdentityUser
{
     public string? FirstName { get; set; }
     public string? LastName { get; set; }
     public string? Kadrovska { get; set; }
}