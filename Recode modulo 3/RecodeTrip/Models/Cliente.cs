using System.ComponentModel.DataAnnotations;

namespace RecodeTrip.Models{
    public class Cliente{
        [Key]
        public int Id_cliente { get; set; }
        [Required]
        public string Nome_completo{ get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public string CPF{ get; set; }
        [Required]
        public int Celular { get; set; }
        [Required]
        public int ViagemId_viagem{ get;set; } 
        public Viagem Viagem{ get; set; }
    }
}