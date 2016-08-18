using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenMVCAjax.Models
{
    public class Inventario
    {
        [Key]
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public int CantidadMinima { get; set; }
        public int CantidadMaxima { get; set; }
        public string Estado { get; set; }
        
        public virtual Producto Producto { get; set; }
    }
}