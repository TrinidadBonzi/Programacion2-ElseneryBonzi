using Microsoft.AspNetCore.Razor.Hosting;
using Veterinaria.Datos.Dtos;
using Veterinaria.Repositorio.Animal;

namespace Veterinaria.Logica.Animal
{
    public class AnimalLogica : IAnimalLogica
    {
        private readonly IAnimalRepositorio _animalRepositorio;

        public AnimalLogica(IAnimalRepositorio animalRepositorio)
        {
            _animalRepositorio = animalRepositorio;
        }
        public AnimalDto ObtenerAnimal(int id)
        {
            Datos.Entidades.Animal animal = _animalRepositorio.ObtenerAnimal(id);

            if (animal == null)
            {
                return null;
            }

            return new AnimalDto
            {
                idAnimal = animal.idAnimal,
                nombreAnimal = animal.nombreAnimal,
                razaAnimal = animal.razaAnimal,
                edadAnimal = animal.edadAnimal,
                sexoAnimal = animal.sexoAnimal,
            };
        }
        public bool EliminarAnimal(int id)
        {
            var animal = _animalRepositorio.ObtenerAnimal(id);
            if (animal == null) return false;

            _animalRepositorio.Eliminar(animal);
            return true;
        }
        public bool AgregarAnimal(AnimalDto nuevoAnimal)
        {
            if (nuevoAnimal == null)
            {
                return false;
            }

            var animalEntidad = new Datos.Entidades.Animal
            {
                idAnimal = nuevoAnimal.idAnimal,
                nombreAnimal = nuevoAnimal.nombreAnimal,
                razaAnimal = nuevoAnimal.razaAnimal,
                edadAnimal = nuevoAnimal.edadAnimal,
                sexoAnimal = nuevoAnimal.sexoAnimal,
                idDuenio = nuevoAnimal.idDuenio,
            };

            _animalRepositorio.Agregar(animalEntidad);
            return true;
        }
        public bool ActualizarAnimal(int id, AnimalDto animalDto)
        {
            if (animalDto == null)
            {
                return false;
            }
            var animalExistente = _animalRepositorio.ObtenerAnimal(id);
            if (animalExistente == null)
            {
                return false;
            }
            animalExistente.nombreAnimal = animalDto.nombreAnimal;
            animalExistente.razaAnimal = animalDto.razaAnimal;
            animalExistente.edadAnimal = animalDto.edadAnimal;
            animalExistente.sexoAnimal = animalDto.sexoAnimal;
            _animalRepositorio.Actualizar(animalExistente);
            return true;
        }


    }
}
