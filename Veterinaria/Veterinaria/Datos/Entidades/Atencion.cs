namespace Veterinaria.Datos.Entidades
{
    public class Atencion
    {
        public int idAtencion { get; set; }
        public DateTime fechaAtencion { get; set; }
        public string motivoAtencion { get; set; }
        public string tratamientoAtencion { get; set; }
        public string medicamentoAtencion { get; set; }
        public DateTime fechaRegistroAtencion { get; set; }
        public Animal Animal { get; set; }
        public int idAnimal { get; set; } 
    }
}
