using Microsoft.EntityFrameworkCore;
using AppDotacion.Models;

namespace AppDotacion.Data
{
    public class AppDotacionContext : DbContext
    {
        public AppDotacionContext(DbContextOptions<AppDotacionContext> options)
            : base(options)
        {
        }

        public DbSet<Dotacion> Dotaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dotacion>(entity =>
            {
                entity.ToTable("Dotaciones");

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .HasColumnType("smallint")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rut_DNI).HasColumnName("Rut_DNI").HasColumnType("nvarchar(50)");
                entity.Property(e => e.Agente).HasColumnName("Agente").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Pais_Call_Center).HasColumnName("Pais_Call_Center").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Nombre_Call_Center).HasColumnName("Nombre_Call_Center").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Area).HasColumnName("Area").HasColumnType("nvarchar(100)");
                entity.Property(e => e.AreaGestion).HasColumnName("AreaGestion").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Contrato).HasColumnName("Contrato").HasColumnType("tinyint");
                entity.Property(e => e.Tipos_de_agente).HasColumnName("Tipos_de_agente").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Servicio).HasColumnName("Servicio").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Usuarios_RcWeb).HasColumnName("Usuarios_RcWeb").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Nombre_Jefatura).HasColumnName("Nombre_Jefatura").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Rut_Ficticio).HasColumnName("Rut_Ficticio").HasColumnType("nvarchar(50)");
                entity.Property(e => e.Rut_DNI2).HasColumnName("Rut_DNI2").HasColumnType("nvarchar(50)");
                entity.Property(e => e.DV).HasColumnName("DV").HasColumnType("tinyint");
                entity.Property(e => e.Clasifica_Cargo).HasColumnName("Clasifica_Cargo").HasColumnType("nvarchar(100)");
                entity.Property(e => e.CARGO).HasColumnName("CARGO").HasColumnType("nvarchar(100)");
                entity.Property(e => e.Fecha_IngresoInt).HasColumnName("Fecha_Ingreso").HasColumnType("int");
                entity.Property(e => e.Fecha_BajaInt).HasColumnName("Fecha_Baja").HasColumnType("int");
                entity.Property(e => e.N_Personal).HasColumnName("N_Personal").HasColumnType("int");
                entity.Property(e => e.Correo).HasColumnName("Correo").HasColumnType("nvarchar(100)");
            });
        }
    }
}