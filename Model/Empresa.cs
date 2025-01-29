using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIEcommerceCoreMVC.Model
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public Int64 id { get; set; }
        public string? nome_fantasia { get; set; }
        public string? logradouro { get; set; }
        public string? numero { get; set; }
        public string? complemento { get; set; }
        public string? cep { get; set; }
        public string? cadastro { get; set; }   
        public string? cnpj { get; set; }
    }
}
