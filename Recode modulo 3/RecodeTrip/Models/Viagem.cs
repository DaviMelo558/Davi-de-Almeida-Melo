using System.ComponentModel.DataAnnotations;

namespace RecodeTrip.Models
{
    public class Viagem
    {
        [Key]
        public int Id_viagem { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Origem { get; set; }
        [Required]
        public string Destino { get; set; }
        [Required]
        public decimal Preco { get; set; }
        [Required]
        public string Data_ida { get; set; }
        [Required]
        public int CompanhiaId_companhia { get; set; }
        public Companhia Companhia {get;set;}
        
        
        
        
        
        
        
        
        
    }
}