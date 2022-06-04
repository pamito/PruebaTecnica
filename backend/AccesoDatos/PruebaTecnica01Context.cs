using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.AccesoDatos
{
    public partial class PruebaTecnica01Context : DbContext
    {
        public PruebaTecnica01Context()
        {
        }

        public PruebaTecnica01Context(DbContextOptions<PruebaTecnica01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<GeneroPersona> GeneroPersona { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<PedidoDetalle> PedidoDetalle { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<TipoEstado> TipoEstado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK_Categoria");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.CodigoCiudad);

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.DireccionCorrespondencia).HasMaxLength(200);

                entity.Property(e => e.DireccionPrincipal)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.EmailFacturacionElectronica)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.EmailGeneral1).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.Nit)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.TelefonoContacto1)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.CodigoEstado);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreEstado)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<GeneroPersona>(entity =>
            {
                entity.HasKey(e => e.CodigoGenero);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.Property(e => e.DireccionDespacho)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaDespacho).HasColumnType("datetime");

                entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Observaciones)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<PedidoDetalle>(entity =>
            {
                entity.HasKey(e => e.IdPedidoDetalle);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(16, 2)");

                entity.Property(e => e.TotalLinea).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.Property(e => e.CodigoEstado).HasDefaultValueSql("((1))");

                entity.Property(e => e.CodigoProducto)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.Eanproducto)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("EANProducto");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Precio).HasColumnType("decimal(16, 2)");
            });

            modelBuilder.Entity<TipoEstado>(entity =>
            {
                entity.HasKey(e => e.CodigoTipoEstado);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
