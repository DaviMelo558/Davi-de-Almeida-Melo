using System.ComponentModel.DataAnnotations;

namespace RecodeTrip.Models
{
    public class Companhia
    {
        [Key]
        public int Id_companhia { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Nota_avaliacao { get; set; }
        
        
        
        
        
        
    }
}