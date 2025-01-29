namespace WebAPIEcommerceCoreMVC.Model
{
    public class Produto
    {
        public Int64 id { get; set; }
        public string? nome { get; set; }
        public int? quantidade { get; set; }
        public double? valor { get; set; }
        public string? validade { get; set; }
        public string? cadastro { get; set; }
        public Int64 empresaId { get; set; }
    }
}
