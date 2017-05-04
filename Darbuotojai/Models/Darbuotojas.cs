using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Darbuotojai.Models
{
    public class Darbuotojas
    {
        public int ID { get; set; }
        [StringLength(20, ErrorMessage = "Vardas negali būti ilgesnis nei 20 simbolių")]
        [Required(ErrorMessage = "Vardas yra privalomas")]
        public string Vardas { get; set; }
        [StringLength(20, ErrorMessage = "Pavardė negali būti ilgesnė nei 20 simbolių")]
        [Required(ErrorMessage = "Pavardė yra privaloma")]
        public string Pavardė { get; set; }
        [Range(1900, 2017, ErrorMessage = "Gimimo metai turi būti tarp 1900 ir 2017 metų")]
        [Required(ErrorMessage = "Gimimo metai yra privalomi")]
        [Display(Name = "Gimimo metai")]
        public int GimimoMetai { get; set; }
        public string Telefonas { get; set; }
    }

    public class DarbuotojasDBContext : DbContext
    {
        public DbSet<Darbuotojas> Darbuotojai { get; set; }
    }
}