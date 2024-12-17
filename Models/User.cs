using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationAPI.Models
{
    public class User
    {
        // ID é do tipo GUID gerado automaticamente
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        // Name com coluna varchar e validação obrigatória
        [Column("name", TypeName = "varchar(255)"), Required(ErrorMessage = "Required name")]
        public string Name { get; set; }

        // Email com validação de formato e obrigatória
        [EmailAddress(ErrorMessage = "Email format invalid!")]
        [Column("email", TypeName = "varchar(255)"), Required(ErrorMessage = "Required email!")]
        public string Email { get; set; }

        // Senha com tamanho mínimo e obrigatória
        [MinLength(6, ErrorMessage = "Password must be more than 6 digits long")]
        [Column("password", TypeName = "varchar(255)"), Required(ErrorMessage = "Required password")]
        public string Password { get; set; }

        // Data de criação com a data atual como padrão
        [Column("create_at", TypeName = "timestamp"), Required]
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
