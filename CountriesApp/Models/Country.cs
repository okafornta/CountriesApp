using System.ComponentModel.DataAnnotations;

namespace CountriesApp.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; } 
        public string? Name { get; set; }
        public string? Capital { get; set; }
        public int  Population  { get; set; }
        public decimal Economy { get; set; }
        public string? Curreny { get; set; }
    }
}
