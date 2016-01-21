using System;
using System.ComponentModel.DataAnnotations;
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataZapisu { get; set; }

        public string Stopien { get; set; }
        public string Preferencje { get; set; }

        public int Lekcja_Id { get; set; }
    }

    
}