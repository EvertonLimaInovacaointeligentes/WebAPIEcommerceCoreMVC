using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace WebAPIEcommerceCoreMVC.Model
{
    [Table("Tagueamentos")]
    public class Tagueamentos 
    {
       
        [Key]
        public Int64 id { get; set; }
        public string? screen { get; set; }
        public string? btn_click { get; set; }
        public string? experient_variantext { get; set; }
        public string? version { get; set; }
        public string? so { get; set; }
        public string? model { get; set; }
        public string? date { get; set; }
    }
}
