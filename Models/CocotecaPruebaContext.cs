using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CocontroladorAPI.Models
{
    public partial class CocotecaPruebaContext : DbContext
    {
        public CocotecaPruebaContext()
        {
        }

        public CocotecaPruebaContext(DbContextOptions<CocotecaPruebaContext> opciones)
            : base(opciones)
        {
        }

        public virtual DbSet<CatCategorias> CatCategorias { get; set; }
        public virtual DbSet<CatEditorial> CatEditorial { get; set; }
        public virtual DbSet<CatPaises> CatPaises { get; set; }
        public virtual DbSet<MtoCatCliente> MtoCatCliente { get; set; }
        public virtual DbSet<MtoCatLibros> MtoCatLibros { get; set; }
        public virtual DbSet<TraCompras> TraCompras { get; set; }
        public virtual DbSet<TraConceptoCompra> TraConceptoCompra { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatCategorias>(entity =>
            {
                entity.HasKey(e => e.Idcategoria);

                entity.ToTable("Cat_Categorias");

                entity.Property(e => e.Idcategoria)
                    .HasColumnName("IDCategoria")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatEditorial>(entity =>
            {
                entity.HasKey(e => e.Ideditorial);

                entity.ToTable("Cat_Editorial");

                entity.Property(e => e.Ideditorial)
                    .HasColumnName("IDEditorial")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatPaises>(entity =>
            {
                entity.HasKey(e => e.Idpais);

                entity.ToTable("Cat_Paises");

                entity.Property(e => e.Idpais).HasColumnName("IDPais");

                entity.Property(e => e.Iso3)
                    .HasColumnName("ISO3")
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MtoCatCliente>(entity =>
            {
                entity.HasKey(e => e.Idcliente);

                entity.ToTable("MtoCat_Cliente");

                entity.HasIndex(e => e.Email)
                    .HasName("UK_MtoCat_Cliente")
                    .IsUnique();

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MtoCatLibros>(entity =>
            {
                entity.HasKey(e => e.Idlibro)
                    .HasName("PK_Table_MtoCat_Libros");

                entity.ToTable("MtoCat_Libros");

                entity.HasIndex(e => e.Isbn)
                    .HasName("UK_Table_MtoCat_Libros")
                    .IsUnique();

                entity.Property(e => e.Idlibro).HasColumnName("IDLibro");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.Ideditorial).HasColumnName("IDEditorial");

                entity.Property(e => e.Idpais).HasColumnName("IDPais");

                entity.Property(e => e.Imagen).IsUnicode(false);

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("ISBN")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("money");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdcategoriaNavigation)
                    .WithMany(p => p.MtoCatLibros)
                    .HasForeignKey(d => d.Idcategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MtoCat_Libros_Cat_Categorias");

                entity.HasOne(d => d.IdeditorialNavigation)
                    .WithMany(p => p.MtoCatLibros)
                    .HasForeignKey(d => d.Ideditorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MtoCat_Libros_Cat_Editorial");

                entity.HasOne(d => d.IdpaisNavigation)
                    .WithMany(p => p.MtoCatLibros)
                    .HasForeignKey(d => d.Idpais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MtoCat_Libros_Cat_Paises");
            });

            modelBuilder.Entity<TraCompras>(entity =>
            {
                entity.HasKey(e => e.Idcompra);

                entity.ToTable("Tra_Compras");

                entity.Property(e => e.Idcompra)
                    .HasColumnName("IDCompra")
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaCompra).HasColumnType("datetime");

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.PrecioTotal).HasColumnType("money");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.TraCompras)
                    .HasForeignKey(d => d.Idcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tra_Compras_MtoCat_Cliente");
            });

            modelBuilder.Entity<TraConceptoCompra>(entity =>
            {
                entity.HasKey(e => e.TraCompras);

                entity.ToTable("Tra_ConceptoCompra");

                entity.Property(e => e.TraCompras)
                    .HasColumnName("Tra_Compras")
                    .ValueGeneratedNever();

                entity.Property(e => e.Idcompra).HasColumnName("IDCompra");

                entity.Property(e => e.Idlibro).HasColumnName("IDLibro");

                entity.HasOne(d => d.IdcompraNavigation)
                    .WithMany(p => p.TraConceptoCompra)
                    .HasForeignKey(d => d.Idcompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tra_ConceptoCompra_Tra_Compras");

                entity.HasOne(d => d.IdlibroNavigation)
                    .WithMany(p => p.TraConceptoCompra)
                    .HasForeignKey(d => d.Idlibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tra_ConceptoCompra_MtoCat_Libros");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
