using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Detalle.Entidades{

    public class Suplidores{
        [Key]
        public int SuplidorID { get; set; }
        public string Nombres { get; set; }

        [ForeignKey("SuplidorID")]
        public virtual List<OrdenesDetalle> OrdenesDetalle {get; set;} 

        public Suplidores()
        {
            SuplidorID = 0;
            OrdenesDetalle = new List<OrdenesDetalle>();
        }

    }
    
}