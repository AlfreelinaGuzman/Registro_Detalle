using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Registro_Detalle.Entidades
{
    public class OrdenesDetalle{
        [Key]
        public int ID { get; set; }
        public int OrdenID { get; set; }
        public int SuplidorID { get; set; }
        public int ProductosID { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }

        public OrdenesDetalle()
        {
            ID = 0;
            OrdenID = 0;
            SuplidorID = 0;
            ProductosID = 0;
            Cantidad = 0;
            Costo = 0;
        }

        public OrdenesDetalle(int ordenID, int suplidorID, int productosID, int cantidad, decimal costo)
        {
            ID = 0;
            OrdenID = ordenID;
            SuplidorID = suplidorID;
            ProductosID = productosID;
            Cantidad = cantidad;
            Costo = costo;
        }

       
    }
}