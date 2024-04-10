using System.ComponentModel.DataAnnotations;

namespace _2_4AurorasBricks2.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}