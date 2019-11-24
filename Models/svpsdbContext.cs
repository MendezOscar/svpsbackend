using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace svpsbackend.Models
{
    public partial class svpsdbContext : DbContext
    {
        public svpsdbContext()
        {
        }

        public svpsdbContext(DbContextOptions<svpsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bono> Bono { get; set; }
        public virtual DbSet<Deduccion> Deduccion { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<Permisosxusuario> Permisosxusuario { get; set; }
        public virtual DbSet<Planilla> Planilla { get; set; }
        public virtual DbSet<Puesto> Puesto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-RVM649N\\SQLEXPRESS;Database=svpsdb;User Id=Mendez; Password=M3nd3z; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bono>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Deduccion>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Departamento>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Direccion).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Permisos>(entity =>
            {
                entity.HasKey(e => e.PermisoId);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Permisosxusuario>(entity =>
            {
                entity.HasKey(e => e.Permisoxusuario);
            });

            modelBuilder.Entity<Planilla>(entity =>
            {
                entity.HasKey(e => e.PanillaId)
                    .HasName("PK__Planilla__CDD676FE0880F501");

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<Puesto>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Clave).IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
