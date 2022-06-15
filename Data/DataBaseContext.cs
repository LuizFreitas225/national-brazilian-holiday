using Microsoft.EntityFrameworkCore;
using NationalBrazilianHolidays.Model;

namespace NationalBrazilianHolidays.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-RBOB4GJ\SQLEXPRESS;Initial Catalog=national_brazilian_holidays;Integrated Security=True");
        }
        public DbSet<Continente>? Continentes { get; set; }
        public DbSet<Feriado>? Feriados { get; set; }
        public DbSet<Localidade>? localidades { get; set; }
        public DbSet<Pais>? Paises { get; set; }
    
    }
}
