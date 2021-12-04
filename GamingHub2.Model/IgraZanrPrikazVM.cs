using System;
using System.Collections.Generic;
using System.Text;

namespace GamingHub2.Model
{
    public class IgraZanrPrikazVM
    {
        public class Rows
        {
            public int IgraZanrID { get; set; }
            public string Zanr { get; set; }
        }
        public int IgraID { get; set; }
        public List<Rows> rows { get; set; }
    }
}
