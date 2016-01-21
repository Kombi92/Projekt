using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Projekt.Models;

namespace Projekt.Models
{
    public class UczenLekcjaContext
    {
        public class SzkolaDBContext : DbContext
        {
            public DbSet<Lekcja> Lekcje { get; set; }
            public DbSet<Uczen> Uczniowie { get; set; }
        }
    }
}