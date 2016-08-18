using ExamenMVCAjax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenMVCAjax.Entities
{
    public class FacturaProducto
    {
        public Factura Factura { get; set; }
        public IEnumerable<Producto> Productos { get; set; }
    }
}