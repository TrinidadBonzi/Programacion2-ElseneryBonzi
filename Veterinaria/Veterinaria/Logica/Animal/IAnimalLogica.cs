using Veterinaria.Datos.Dtos;

namespace Veterinaria.Logica.Animal
{
    public interface IAnimalLogica
    {
        AnimalDto ObtenerAnimal(int id);
        bool EliminarAnimal(int id);
        bool AgregarAnimal(AnimalDto nuevoAnimal);
        bool ActualizarAnimal(int id, AnimalDto animalDto);

    }
}
