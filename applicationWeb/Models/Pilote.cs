using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace applicationWeb.Models
{
    public class Pilote
    {

        [Key]

        [DisplayName("Numero Pilote")]
        [Range(1, 11)]
        public int Numpilote { get; set; }

        [DisplayName("Nom Pilote")]

        [MaxLength(20)]
        public string Nompilote { get; set; }


        public string Adresse { get; set; }

        

    }
}
