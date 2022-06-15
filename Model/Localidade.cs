using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NationalBrazilianHolidays.Model
{
    public class Localidade
    {
        [Key]

        public long Id { get; set; }
        public string? Nome { get; set; }

    }
}
