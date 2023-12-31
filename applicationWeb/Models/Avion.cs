using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace applicationWeb.Models
{
    public class Avion
    {
       
        [Key]
        
        [DisplayName("Numero Avion")]
        [Range(1,11)]
        public int Numavion { get; set; }
        
        [DisplayName("Nom Avion")]

        [MaxLength(20)]
        public string Nomavion { get; set; }

        
        public int Capacite { get; set; }

        [MaxLength(20)]
        public string Localisation { get; set; }
    }
}
