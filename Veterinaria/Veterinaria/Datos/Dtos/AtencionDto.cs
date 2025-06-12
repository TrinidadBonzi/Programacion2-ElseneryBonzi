using Veterinaria.Datos.Entidades;

namespace Veterinaria.Datos.Dtos
{
    public class AtencionDto
    {
        public int idAtencion { get; set; }
        public DateTime fechaAtencion { get; set; }
        public string motivoAtencion { get; set; }
        public string tratamientoAtencion { get; set; }
        public string medicamentoAtencion { get; set; }
        public DateTime fechaRegistroAtencion { get; set; }
        public int idMascota { get; set; }
    }
}
