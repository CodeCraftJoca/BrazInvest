using System.ComponentModel.DataAnnotations;

namespace BrazInvest.API.Helpers
{
    public class CreateUserRequest
    {
        [Required]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
