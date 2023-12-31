using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace applicationWeb.Models
{
    public class Vol
    {
        [Key]

        [DisplayName("Numero Vol")]
        [Range(1, 11)]
        public string Numvol { get; set; }

        

        public int Numpilote { get; set; }
        [ForeignKey("Numpilote")]
        public Pilote Pilote { get; set; }
       
        
        

        public int Numavion { get; set; }
        [ForeignKey("Numavion")]
        public Avion Avion { get; set; }


        [DisplayName("Ville  Depart")]

        public string Villedep { get; set; }

        [DisplayName("Ville Arrive")]

        public string Villearr { get; set; }
       
        [DisplayName("Heure  Depart")]

        public string Heuredep { get; set; }

        [DisplayName("Heure Arrive")]

        public string Heurearr { get; set; }




    }
}
