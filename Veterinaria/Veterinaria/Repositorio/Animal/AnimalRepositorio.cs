using Veterinaria.Datos;

namespace Veterinaria.Repositorio.Animal
{
    public class AnimalRepositorio : IAnimalRepositorio
    {
        private readonly ApplicationDbContext _context;

        public AnimalRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public Datos.Entidades.Animal ObtenerAnimal(int id)
        {
            return _context.Animales.FirstOrDefault(x => x.idAnimal == id);
        }
        public void Eliminar(Veterinaria.Datos.Entidades.Animal animal)
        {
            _context.Animales.Remove(animal);
            _context.SaveChanges();
        }
        public void Agregar(Veterinaria.Datos.Entidades.Animal animal)
        {
            _context.Animales.Add(animal);
            _context.SaveChanges();
        }
        public void Actualizar(Veterinaria.Datos.Entidades.Animal animal)
        {
            _context.Animales.Update(animal);
            _context.SaveChanges();
        }
    }
}
