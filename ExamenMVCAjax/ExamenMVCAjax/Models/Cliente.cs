using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenMVCAjax.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Tipo { get; set; }
        public float Descuento { get; set; }
    }
}