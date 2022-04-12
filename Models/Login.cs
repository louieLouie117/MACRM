using System.ComponentModel.DataAnnotations;

namespace KcPilot.Models
{
    public class Login
    {
        public int UserId { get; set; }

        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}