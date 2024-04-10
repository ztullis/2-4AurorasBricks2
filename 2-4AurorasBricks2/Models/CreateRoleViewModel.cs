using System.ComponentModel.DataAnnotations;

namespace _2_4AurorasBricks2.Models
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}