using System.ComponentModel.DataAnnotations;
namespace Dominio
{
    public class Persona
    {
        public int Id { get; set; }
        
        [Required]
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public float Altura { get; set; }
        
    }
}