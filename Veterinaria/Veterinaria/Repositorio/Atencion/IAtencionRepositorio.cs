namespace Veterinaria.Repositorio.Atencion
{
    public interface IAtencionRepositorio
    {
        Datos.Entidades.Atencion ObtenerAtencion(int idAtencion);
        void Eliminar(Datos.Entidades.Atencion atencion);
        void Agregar(Datos.Entidades.Atencion atencion);
        Datos.Entidades.Animal ObtenerAnimal(int idMascota);
        void Actualizar(Datos.Entidades.Atencion atencion);
    }
}
