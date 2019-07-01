using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Almacen.Ingreso

{
    public class DetalleViewModel
    {
        [Required]
        public int idarticulo { get; set; }
        [Required]
        public int cantidad { get; set; }
        [Required]
        public decimal precio { get; set; }
    }
}
