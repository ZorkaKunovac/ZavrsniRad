using System.ComponentModel.DataAnnotations;

namespace GamingHub2.Database
{
    public class Drzava
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Polje je obavezno")]
        public string Naziv { get; set; }
    }
}