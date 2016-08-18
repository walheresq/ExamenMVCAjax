using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenMVCAjax.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ClienteId { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double Impuesto { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
    }
}