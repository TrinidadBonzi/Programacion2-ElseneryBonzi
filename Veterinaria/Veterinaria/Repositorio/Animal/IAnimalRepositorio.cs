using Veterinaria.Datos.Entidades;

namespace Veterinaria.Repositorio.Animal
{
    public interface IAnimalRepositorio
    {
        Datos.Entidades.Animal ObtenerAnimal(int idAnimal);
        void Eliminar(Datos.Entidades.Animal animal);
        void Agregar(Datos.Entidades.Animal animal);
        void Actualizar(Datos.Entidades.Animal animal);

    }
}
