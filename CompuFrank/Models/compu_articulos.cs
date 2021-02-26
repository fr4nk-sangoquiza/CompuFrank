using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompuFrank.Models
{
    public class compu_articulos
    {

        ////////////////////////
        //    PROPIEDADES
        ////////////////////////
        
        [Key]
        public int id { get; set; }

        [Display(Name = "Producto")]
        public string producto { get; set; }

        [Display(Name = "Categoría")]
        public string categoria { get; set; }

        [Display(Name = "Precio")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal precio { get; set; }

        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [Display(Name = "URL")]
        public string url_imagen { get; set; }


    }
}
