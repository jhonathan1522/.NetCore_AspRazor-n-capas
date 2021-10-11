using System.ComponentModel.DataAnnotations;
namespace Dominio
{
    public class Empleado
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }

        public int Edad { get; set; }

        public float Altura { get; set; }
        
    }
}