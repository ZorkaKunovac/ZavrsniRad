using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model
{
    public class Recenzija
    {
        public int ID { get; set; }

        //[MaxLength(250, ErrorMessage = "Maksimalno {1} znakova")]
        public string Naslov { get; set; }
        public string KorisnickoIme { get; set; }
        public DateTime? DatumKreiranja { get; set; }

        //[MaxLength(300, ErrorMessage = "Maksimalno {1} znakova")]
        public string Sadrzaj { get; set; }
        public string Slika { get; set; }
    }
}
