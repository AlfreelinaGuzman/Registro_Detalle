using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Registro_Detalle.Entidades
{
    public class Productos{
        [Key]
        public int ProductosID { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int Inventario { get; set; }
        
    }
}