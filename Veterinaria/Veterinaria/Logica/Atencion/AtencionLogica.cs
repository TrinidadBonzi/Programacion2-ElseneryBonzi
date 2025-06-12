using Veterinaria.Datos.Dtos;
using Veterinaria.Logica.Atencion;
using Veterinaria.Repositorio.Atencion;

namespace Veterinaria.Logica.Atencion
{
    public class AtencionLogica : IAtencionLogica
    {
        private readonly IAtencionRepositorio _atencionRepositorio;

        public AtencionLogica(IAtencionRepositorio atencionRepositorio)
        {
            _atencionRepositorio = atencionRepositorio;
        }
        public AtencionDto ObtenerAtencion(int id)
        {
            Datos.Entidades.Atencion atencion = _atencionRepositorio.ObtenerAtencion(id);

            if (atencion == null)
            {
                return null;
            }

            return new AtencionDto
            {
                idAtencion = atencion.idAtencion,
                fechaAtencion = atencion.fechaAtencion,
                motivoAtencion = atencion.motivoAtencion,
                tratamientoAtencion = atencion.tratamientoAtencion,
                medicamentoAtencion = atencion.medicamentoAtencion,
                fechaRegistroAtencion = atencion.fechaRegistroAtencion
            };
        }
        public bool EliminarAtencion(int id)
        {
            var atencion = _atencionRepositorio.ObtenerAtencion(id);
            if (atencion == null) return false;

            _atencionRepositorio.Eliminar(atencion);
            return true;
        }
        public bool AgregarAtencion(AtencionDto nuevaAtencion)
        {
            if (nuevaAtencion == null)
            {
                return false;
            }

            if (nuevaAtencion.fechaAtencion > DateTime.Now)
            {
                throw new ArgumentException("La fecha de atención no puede ser futura.");
            }

            if (nuevaAtencion.fechaRegistroAtencion < nuevaAtencion.fechaAtencion)
            {
                throw new ArgumentException("La fecha de registro debe ser igual o posterior a la fecha de atención.");
            }

            var atencionEntidad = new Datos.Entidades.Atencion
            {
                idAtencion = nuevaAtencion.idAtencion,
                fechaAtencion = nuevaAtencion.fechaAtencion,
                motivoAtencion = nuevaAtencion.motivoAtencion,
                tratamientoAtencion = nuevaAtencion.tratamientoAtencion,
                medicamentoAtencion = nuevaAtencion.medicamentoAtencion,
                fechaRegistroAtencion = nuevaAtencion.fechaRegistroAtencion,
                idAnimal = nuevaAtencion.idMascota
            };
            _atencionRepositorio.Agregar(atencionEntidad);
            return true;
        }
        public bool ActualizarAtencion(int id, AtencionDto atencionDto)
        {
            if (atencionDto == null)
            {
                return false;
            }
            var atencion = _atencionRepositorio.ObtenerAtencion(id);
            if (atencion == null)
            {
                return false;
            }
            atencion.fechaAtencion = atencionDto.fechaAtencion;
            atencion.motivoAtencion = atencionDto.motivoAtencion;
            atencion.tratamientoAtencion = atencionDto.tratamientoAtencion;
            atencion.medicamentoAtencion = atencionDto.medicamentoAtencion;
            _atencionRepositorio.Actualizar(atencion);
            return true;
        }
    }
}
