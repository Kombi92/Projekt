using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projekt.Models
{
    public class Lekcja
    {
        public int ID { get; set; }
        
        public string Typ { get; set; }

        public string IloscGodzin { get; set; }

    }

    
}
