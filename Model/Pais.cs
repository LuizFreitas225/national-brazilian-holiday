using System.ComponentModel.DataAnnotations.Schema;

namespace NationalBrazilianHolidays.Model
{
    [Table("Pais")]
    public class Pais : Localidade
    {
        public string? Sigla { get; set; }

        public  Continente? Continente { get; set; }

        public  ICollection<Feriado>? Feriados { get; set; }
    }
}
