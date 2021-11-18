using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class AutorizacijskiTokenInsertRequest
    {
        public string Vrijednost { get; set; }
        public int KorisnikId { get; set; }
        public DateTime VrijemeEvidentiranja { get; set; }
    }
}
