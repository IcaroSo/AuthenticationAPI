using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Required name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Required email!")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Required password")]
        public required string Password { get; set; }
    }
}
