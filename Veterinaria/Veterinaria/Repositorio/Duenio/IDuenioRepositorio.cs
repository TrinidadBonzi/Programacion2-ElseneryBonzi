namespace Veterinaria.Repositorio.Duenio
{
    public interface IDuenioRepositorio
    {
        Datos.Entidades.Duenio ObtenerDuenio(int idDuenio);
        void Eliminar(Datos.Entidades.Duenio duenio);
        void Agregar(Datos.Entidades.Duenio duenio);
        void Actualizar(Datos.Entidades.Duenio duenio);
    }
}
