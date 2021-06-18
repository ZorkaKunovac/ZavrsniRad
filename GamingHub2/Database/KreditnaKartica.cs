using GamingHub2.Database;
using System;
using System.ComponentModel.DataAnnotations;

namespace GamingHub2.Database
{
    public class KreditnaKartica
    {
        public int ID { get; set; }
        public int TipKarticeID { get; set; }
        public TipKartice TipKartice { get; set; }

        [RegularExpression(@"^\d{13,19}$", ErrorMessage = "Obavezno izmedju 13 i 19 brojeva")]
        public int BrojKartice { get; set; }

        [Range(1, 12)]
        public int MjesecVazenja { get; set; }

        [Range(2021, 2030)]
        public int GodinaVazenja { get; set; }

        [RegularExpression(@"^\d{3,4}$", ErrorMessage = "Obicno sadrzi 3 ili 4 cifre")]
        public int SigurnosniKod { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
