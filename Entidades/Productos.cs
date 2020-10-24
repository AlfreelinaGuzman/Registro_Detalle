using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Detalle.Entidades
{
    public class Productos{
        [Key]
        public int ProductosID { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public int Inventario { get; set; }

        [ForeignKey("ProductosID")]
        public virtual List<OrdenesDetalle> OrdenesDetalle {get; set;} 
        
        public Productos()
        {
            ProductosID = 0;
            OrdenesDetalle = new List<OrdenesDetalle>();
        }
        
    }
}