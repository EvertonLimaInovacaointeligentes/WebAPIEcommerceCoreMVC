using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPIEcommerceCoreMVC.Model
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public Int64 id { get; set; }
        public string nome_fantasia { get; set; }
        public string data_cadastro { get; set; }       
    }
}
