using Veterinaria.Datos.Entidades;

namespace Veterinaria.Datos.Dtos
{
    public class AnimalDto
    {
        public int idAnimal { get; set; }
        public string nombreAnimal { get; set; }
        public string razaAnimal { get; set; }
        public int edadAnimal { get; set; }
        public string sexoAnimal { get; set; }
        public int idDuenio { get; set; }
        
    }
}
