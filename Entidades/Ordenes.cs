using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Detalle.Entidades
{
    public class Ordenes{
        [Key]
        public int OrdenID { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public int SuplidorID { get; set; }
        public int ProductosID { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("OrdenID")]
        public virtual List<OrdenesDetalle> OrdenesDetalle {get; set;} = new List<OrdenesDetalle>();

        public Ordenes()
        {
            OrdenID = 0;
            Fecha = DateTime.Now;
            SuplidorID = 0;
            ProductosID= 0;
            Monto = 0;
            OrdenesDetalle = new List<OrdenesDetalle>();
        }

    }
}