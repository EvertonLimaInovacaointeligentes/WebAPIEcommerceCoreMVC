using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIEcommerceCoreMVC.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public Int64 id { get; set; }
        public string nome { get; set ; }
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public string logradouro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string cadastro { get; set; }
        [ForeignKey("Login")]
        public Int64 loginId { get; set; }
         
    }
}
