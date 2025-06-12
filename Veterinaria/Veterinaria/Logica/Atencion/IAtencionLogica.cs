using Veterinaria.Datos.Dtos;

namespace Veterinaria.Logica.Atencion
{
    public interface IAtencionLogica
    {
        AtencionDto ObtenerAtencion(int id);
        bool EliminarAtencion(int id);
        bool AgregarAtencion(AtencionDto nuevaAtencion);
        bool ActualizarAtencion(int id, AtencionDto atencionDto);
    }
}
