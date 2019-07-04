using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Web.Models.Ventas.Venta
{
    public class CrearViewModel
    {
        //Propiedades Maestro
        [Required]
        public int idusuario { get; set; }
        [Required]
        public int idcliente { get; set; }
        [Required]
        public string tipo_comprobante { get; set; }
        public string serie_comprobante { get; set; }
        [Required]
        public string num_comprobante { get; set; }
        [Required]
        public decimal impuesto { get; set; }
        [Required]
        public decimal total { get; set; }
        //Propiedad Detalle
        public List<DetalleViewModel> detalles { get; set; }
    }
}
