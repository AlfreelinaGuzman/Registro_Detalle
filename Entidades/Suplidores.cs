using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Detalle.Entidades{

    public class Suplidores{
        [Key]
        public int SulidoresID { get; set; }
        public string Nombres { get; set; }

        [ForeignKey("SuplidoresID")]
        public virtual List<OrdenesDetalle> OrdenesDetalle {get; set;} 

        public Suplidores()
        {
            Suplidores = 0;
            OrdenesDetalle = new List<OrdenesDetalle>();
        }

    }
    
}