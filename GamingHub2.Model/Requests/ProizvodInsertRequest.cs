﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GamingHub2.Model.Requests
{
    public class ProizvodInsertRequest
    {
        //[Required(ErrorMessage = "Polje je obavezno")]
        //[StringLength(50, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 3)]
        [Display(Name = "Naziv proizvoda")]
        public string NazivProizvoda { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(8, 2)")]
        [Display(Name = "Cijena")]
        public decimal ProdajnaCijena { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Polje je obavezno")]
        public decimal Popust { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        public bool Status { get; set; }
        [Required]

        [Display(Name = "Igra-Konzola")]
        public int IgraKonzolaID { get; set; }
        public List<SelectListItem> IgraKonzola { get; set; }

    }
}
