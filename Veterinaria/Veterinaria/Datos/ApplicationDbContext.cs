using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Veterinaria.Datos.Entidades;

namespace Veterinaria.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Datos.Entidades.Animal> Animales { get; set; } = default!;
        public DbSet<Datos.Entidades.Duenio> Duenios { get; set; } = default!;
        public DbSet<Datos.Entidades.Atencion> Atenciones { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.HasKey(e => e.idAnimal)  
                    .HasName("PK_ID_ANIMAL");
                entity.HasOne(e => e.duenio)  
                    .WithMany()  
                    .HasForeignKey("idDuenio"); 
            });
            modelBuilder.Entity<Duenio>(entity =>
            {
                entity.HasKey(e => e.idDuenio)  
                    .HasName("PK_ID_DUENIO");  
            });
            modelBuilder.Entity<Atencion>(entity =>
            {
                entity.HasKey(e => e.idAtencion) 
                    .HasName("PK_ID_ATENCION");  

                entity.HasOne(e => e.Animal)  
                    .WithMany()  
                    .HasForeignKey("idAnimal");  
            });
        }
    }
}
