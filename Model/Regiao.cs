using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nationalHolidays.Model
{
    public class Regiao
    {   
        [Key]
        public long Id { get; set; }
        public string?Nome { get; set; }
    }
}
