using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace _2_4AurorasBricks2.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
