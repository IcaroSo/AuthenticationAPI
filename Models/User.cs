using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column("name", TypeName = "varchar(255)"), Required(ErrorMessage = "Required name")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Email format invalid!")]
        [Column("email", TypeName = "varchar(255)"), Required(ErrorMessage = "Required email!")]
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Password must be more than 6 digits long")]
        [Column("password", TypeName = "varchar(255)"), Required(ErrorMessage = "Required password")]
        public string Password { get; set; }

        [Column("create_at", TypeName = "timestamp"), Required]
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
