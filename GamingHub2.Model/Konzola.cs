﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GamingHub2.Model
{
    public class Konzola
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Polje je obavezno")]
        [StringLength(40, ErrorMessage = "{0} mora biti izmedju {2} i {1} znakova.", MinimumLength = 2)]
        public string Naziv { get; set; }

        [MaxLength(500, ErrorMessage = "Maksimalno 500 znakova")]
        public string Detalji { get; set; }
    }
}
