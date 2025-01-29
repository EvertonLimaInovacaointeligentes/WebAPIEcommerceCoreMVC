using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIEcommerceCoreMVC.Model
{
    [Table("Login")]
    public class Login
    {
        [Key]
        public Int64 id { get; set; }
        public string? login { get; set; }
        public string? senha { get; set; }
        public string? cadastro { get; set; }
        [ForeignKey("Empresa")]
        public Int64 empresaId { get; set; }
    }
}
