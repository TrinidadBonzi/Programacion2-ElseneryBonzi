using Veterinaria.Datos.Dtos;
using Veterinaria.Logica.Duenio;
using Veterinaria.Repositorio.Duenio;

namespace Veterinaria.Logica.Duenio
{
    public class DuenioLogica : IDuenioLogica
    {
        private readonly IDuenioRepositorio _duenioRepositorio;

        public DuenioLogica(IDuenioRepositorio duenioRepositorio)
        {
            _duenioRepositorio = duenioRepositorio;
        }
        public DuenioDto ObtenerDuenio(int id)
        {
            Datos.Entidades.Duenio duenio = _duenioRepositorio.ObtenerDuenio(id);

            if (duenio == null)
            {
                return null;
            }

            return new DuenioDto
            {
                dniDuenio = duenio.dniDuenio,
                nombreDuenio = duenio.nombreDuenio,
                apellidoDuenio = duenio.apellidoDuenio,
            };
        }
        public bool EliminarDuenio(int id)
        {
            var duenio = _duenioRepositorio.ObtenerDuenio(id);
            if (duenio == null) return false;

            _duenioRepositorio.Eliminar(duenio);
            return true;
        }
        public bool AgregarDuenio(DuenioDto nuevoDuenio)
        {
            if (nuevoDuenio == null)
            {
                return false;
            }
            var duenioEntidad = new Datos.Entidades.Duenio
            {
                idDuenio = nuevoDuenio.idDuenio,
                dniDuenio = nuevoDuenio.dniDuenio,
                nombreDuenio = nuevoDuenio.nombreDuenio,
                apellidoDuenio = nuevoDuenio.apellidoDuenio,
            };
            _duenioRepositorio.Agregar(duenioEntidad);
            return true;
        }
        public bool ActualizarDuenio(int id, DuenioDto duenioDto)
        {
            if (duenioDto == null)
            {
                return false;
            }
            var duenioEntidad = _duenioRepositorio.ObtenerDuenio(id);
            if (duenioEntidad == null)
            {
                return false;
            }
            duenioEntidad.idDuenio = duenioDto.idDuenio;
            duenioEntidad.dniDuenio = duenioDto.dniDuenio;
            duenioEntidad.nombreDuenio = duenioDto.nombreDuenio;
            duenioEntidad.apellidoDuenio = duenioDto.apellidoDuenio;

            _duenioRepositorio.Actualizar(duenioEntidad);
            return true;
        }
    }
}
