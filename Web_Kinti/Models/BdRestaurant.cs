using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_Kinti.Models;

public partial class BdRestaurant : DbContext
{
    public BdRestaurant()
    {
    }

    public BdRestaurant(DbContextOptions<BdRestaurant> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Comidum> Comida { get; set; }

    public virtual DbSet<Mesa> Mesas { get; set; }

    public virtual DbSet<Reservacion> Reservacions { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CHAUFITA\\SQLEXPRESS04;Initial Catalog=DBRestaurant;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__8A3D240CA3902A5E");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Comidum>(entity =>
        {
            entity.HasKey(e => e.IdComida).HasName("PK__Comida__B2ADDC3C723577B2");

            entity.Property(e => e.IdComida).HasColumnName("idComida");
            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("codigoBarra");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("urlFoto");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Comida)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Comida__idCatego__398D8EEE");
        });

        modelBuilder.Entity<Mesa>(entity =>
        {
            entity.HasKey(e => e.IdMesa).HasName("PK__Mesa__C26D1DFF7D569712");

            entity.ToTable("Mesa");

            entity.Property(e => e.IdMesa).HasColumnName("idMesa");
            entity.Property(e => e.IdReservacion).HasColumnName("idReservacion");

            entity.HasOne(d => d.IdReservacionNavigation).WithMany(p => p.Mesas)
                .HasForeignKey(d => d.IdReservacion)
                .HasConstraintName("FK__Mesa__idReservac__440B1D61");
        });

        modelBuilder.Entity<Reservacion>(entity =>
        {
            entity.HasKey(e => e.IdReservacion).HasName("PK__Reservac__C813D8AD2249298A");

            entity.ToTable("Reservacion");

            entity.Property(e => e.IdReservacion).HasColumnName("idReservacion");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Reservacions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Reservaci__idUsu__412EB0B6");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F76B56A8ED3");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__645723A6D2385B41");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("urlFoto");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__idRol__3E52440B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
