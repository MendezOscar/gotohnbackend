using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace gotohnbackend.Models
{
    public partial class gotoTripContext : DbContext
    {
        public gotoTripContext()
        {
        }

        public gotoTripContext(DbContextOptions<gotoTripContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividades> Actividades { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<ItinerarioDetalle> ItinerarioDetalle { get; set; }
        public virtual DbSet<ItinerarioEncabezado> ItinerarioEncabezado { get; set; }
        public virtual DbSet<Jornada> Jornada { get; set; }
        public virtual DbSet<Lugar> Lugar { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User ID = postgres;Password=gotohnserver;Server=localhost;Port=5432;Database=gotoTrip;Integrated Security=true; Pooling=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividades>(entity =>
            {
                entity.HasKey(e => e.Actividadid)
                    .HasName("actividades_pkey");

                entity.ToTable("actividades");

                entity.Property(e => e.Actividadid)
                    .HasColumnName("actividadid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Categoriaid).HasColumnName("categoriaid");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Duracion)
                    .HasColumnName("duracion")
                    .HasColumnType("date");

                entity.Property(e => e.Horario)
                    .HasColumnName("horario")
                    .HasColumnType("character varying");

                entity.Property(e => e.Jornadaid).HasColumnName("jornadaid");

                entity.Property(e => e.Lugarid).HasColumnName("lugarid");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.Categoriaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_categoriaid");

                entity.HasOne(d => d.Jornada)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.Jornadaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_jornadaid");

                entity.HasOne(d => d.Lugar)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.Lugarid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_lugarid");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("categoria");

                entity.Property(e => e.Categoriaid)
                    .HasColumnName("categoriaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<ItinerarioDetalle>(entity =>
            {
                entity.ToTable("itinerario_detalle");

                entity.Property(e => e.ItinerarioDetalleid)
                    .HasColumnName("itinerario_detalleid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Actividadid).HasColumnName("actividadid");

                entity.Property(e => e.Itinierarioid).HasColumnName("itinierarioid");

                entity.Property(e => e.Prioridad).HasColumnName("prioridad");

                entity.HasOne(d => d.Actividad)
                    .WithMany(p => p.ItinerarioDetalle)
                    .HasForeignKey(d => d.Actividadid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_actividadid");

                entity.HasOne(d => d.Itinierario)
                    .WithMany(p => p.ItinerarioDetalle)
                    .HasForeignKey(d => d.Itinierarioid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_itinierarioid");
            });

            modelBuilder.Entity<ItinerarioEncabezado>(entity =>
            {
                entity.HasKey(e => e.Itinierarioid)
                    .HasName("itinerario_encabezado_pkey");

                entity.ToTable("itinerario_encabezado");

                entity.Property(e => e.Itinierarioid)
                    .HasColumnName("itinierarioid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Fechafinal).HasColumnName("fechafinal");

                entity.Property(e => e.Fechainicio)
                    .HasColumnName("fechainicio")
                    .HasColumnType("date");

                entity.Property(e => e.Lugarid).HasColumnName("lugarid");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Jornada>(entity =>
            {
                entity.ToTable("jornada");

                entity.Property(e => e.Jornadaid)
                    .HasColumnName("jornadaid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Lugar>(entity =>
            {
                entity.ToTable("lugar");

                entity.Property(e => e.Lugarid)
                    .HasColumnName("lugarid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .HasColumnType("character varying");

                entity.Property(e => e.Horacierre)
                    .HasColumnName("horacierre")
                    .HasColumnType("date");

                entity.Property(e => e.Horaentrada)
                    .HasColumnName("horaentrada")
                    .HasColumnType("date");

                entity.Property(e => e.Lugar1)
                    .HasColumnName("lugar")
                    .HasColumnType("character varying");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.Property(e => e.Usuarioid)
                    .HasColumnName("usuarioid")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasColumnName("clave")
                    .HasColumnType("character varying");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("character varying");

                entity.Property(e => e.Tipo).HasColumnName("tipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
