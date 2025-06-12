using Veterinaria.Datos;

namespace Veterinaria.Repositorio.Duenio
{
    public class DuenioRepositorio : IDuenioRepositorio
    {
        private readonly ApplicationDbContext _context;

        public DuenioRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }
        public Datos.Entidades.Duenio ObtenerDuenio(int id)
        {
            return _context.Duenios.FirstOrDefault(x => x.idDuenio == id);
        }
        public void Eliminar(Veterinaria.Datos.Entidades.Duenio duenio)
        {
            _context.Duenios.Remove(duenio);
            _context.SaveChanges();
        }
        public void Agregar(Veterinaria.Datos.Entidades.Duenio duenio)
        {
            _context.Duenios.Add(duenio);
            _context.SaveChanges();
        }
        public void Actualizar(Datos.Entidades.Duenio duenio)
        {
            _context.Duenios.Update(duenio);
            _context.SaveChanges();
        }

    }
}
