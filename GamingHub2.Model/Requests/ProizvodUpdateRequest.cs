using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GamingHub2.Model.Requests
{
    public class ProizvodUpdateRequest
    {
        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]
        public string NazivProizvoda { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ProdajnaCijena { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Popust { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public bool? Status { get; set; }
    }
}
