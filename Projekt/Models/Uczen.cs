using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Data.Entity;

namespace Projekt.Models
{
    public class Uczen
    {
        public int ID { get; set; }
        
        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        [Display(Name = "Data Zapisu")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataZapisu { get; set; }

        [DisplayName("Stopień"),Required(ErrorMessage = "Proszę podać stopień zaawansowania.")]
        public string Stopien { get; set; }
        public string Preferencje { get; set; }

        public virtual Lekcja Lekcja { get; set; }
    }

    
}