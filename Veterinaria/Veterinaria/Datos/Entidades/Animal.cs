using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Veterinaria.Datos.Entidades
{
    public class Animal
    {
        public int idAnimal { get; set; }
        public string nombreAnimal { get; set; }
        public string razaAnimal { get; set; }
        public int edadAnimal { get; set; }
        public string sexoAnimal { get; set; }
        public int idDuenio { get; set; } 
        public Duenio? duenio { get; set; }
        public ICollection<Atencion> Atenciones { get; set; }
    }
}
