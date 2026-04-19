using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using trabajo_de_SF2.Models;


namespace trabajo_de_SF2.Data
{
    public class AppDbContext  : DbContext
    {
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<ProveedorCloud> Proveedores { get; set; }
        public DbSet<GrupoRespuesta> GruposRespuesta { get; set; }
        public DbSet<ReglaMotor> Reglas { get; set; }
        public DbSet<ServicioMonitoreo> Servicios { get; set; }
        public DbSet<IncidentModel> Incidents { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ClientModel
            modelBuilder.Entity<ClientModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CompanyName)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(e => e.AdminEmail)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(e => e.Service)
                      .HasMaxLength(100);

                entity.Property(e => e.CreatedDate)
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            // ProveedorCloud
            modelBuilder.Entity<ProveedorCloud>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            // GrupoRespuesta
            modelBuilder.Entity<GrupoRespuesta>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            // ReglaMotor
            modelBuilder.Entity<ReglaMotor>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            // ServicioMonitoreo
            modelBuilder.Entity<ServicioMonitoreo>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            // IncidentModel
            modelBuilder.Entity<IncidentModel>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Title).HasMaxLength(200);
                entity.Property(e => e.Provider).HasMaxLength(100);
            });

            // ⚠️ Ignorar propiedades complejas (listas)
            modelBuilder.Entity<IncidentModel>().Ignore(i => i.Timeline);
            modelBuilder.Entity<IncidentModel>().Ignore(i => i.ImpactedServices);
            modelBuilder.Entity<IncidentModel>().Ignore(i => i.OfficialLinks);
            modelBuilder.Entity<IncidentModel>().Ignore(i => i.Responders);
        }
    }
}