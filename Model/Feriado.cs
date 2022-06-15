using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationalBrazilianHolidays.Model
{
    public class Feriado
    {
        [Key]

        public long Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? Data { get; set; }
        public long? Ano { get; set; }

        public  ICollection<Pais>? Paises { get; set; }


    }
}
