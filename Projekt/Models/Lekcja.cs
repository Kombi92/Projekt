using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Projekt.Validators;

namespace Projekt.Models
{
    public class Lekcja
    {
        public int ID { get; set; }

        [Required]
        [TypVal( "Typ",ErrorMessage ="Podaj prawidłowy Typ")]
        public string Typ { get; set; }

        public string IloscGodzin { get; set; }

        public virtual ICollection<Uczen> Uczniowie { get; set; }

    }

    
}
