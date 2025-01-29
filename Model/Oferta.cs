using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIEcommerceCoreMVC.Model
{
    [Table("Oferta")]
    public class Oferta
    {
        public Int64 id { get; set; }
        public string? validade { get; set; }
        public string? oferta { get; set; }
        [ForeignKey("Produto")]
        public Int64 produtoId { get; set; }
        [ForeignKey("Empresa")]
        public Int64 empresaId { get; set; }
    }
}
