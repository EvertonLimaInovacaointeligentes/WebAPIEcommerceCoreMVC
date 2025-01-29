using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIEcommerceCoreMVC.Model
{
    public class Chat
    {
        public Int64 id { get; set; }
        public string? assunto { get; set; }
        public string? texto { get; set; }
        public string? data_chat { get; set; }
        [ForeignKey("Empresa")]
        public Int64 empresaId { get; set; }
        [ForeignKey("Usuario")]
        public Int64 usuarioId { get; set; }
    }
}
