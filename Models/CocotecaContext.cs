using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CocontroladorAPI.Models
{
    public partial class CocotecaContext : DbContext
    {
        public CocotecaContext()
        {
        }

        public CocotecaContext(DbContextOptions<CocotecaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatCategorias> CatCategorias { get; set; }
        public virtual DbSet<CatDirecciones> CatDirecciones { get; set; }
        public virtual DbSet<CatEditorial> CatEditorial { get; set; }
        public virtual DbSet<CatEstados> CatEstados { get; set; }
        public virtual DbSet<CatEstadosMunicipios> CatEstadosMunicipios { get; set; }
        public virtual DbSet<CatMunicipios> CatMunicipios { get; set; }
        public virtual DbSet<CatPaises> CatPaises { get; set; }
        public virtual DbSet<MtoCatLibros> MtoCatLibros { get; set; }
        public virtual DbSet<MtoCatUsuarios> MtoCatUsuarios { get; set; }
        public virtual DbSet<TraCompras> TraCompras { get; set; }
        public virtual DbSet<TraConceptoCompra> TraConceptoCompra { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatCategorias>(entity =>
            {
                entity.HasKey(e => e.Idcategoria);

                entity.ToTable("Cat_Categorias");

                entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatDirecciones>(entity =>
            {
                entity.HasKey(e => e.Iddireccion);

                entity.ToTable("Cat_Direcciones");

                entity.Property(e => e.Iddireccion).HasColumnName("IDDireccion");

                entity.Property(e => e.Calle)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Idmunicipio).HasColumnName("IDMunicipio");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.NoInterior)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdmunicipioNavigation)
                    .WithMany(p => p.CatDirecciones)
                    .HasForeignKey(d => d.Idmunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cat_Direcciones_Cat_Municipios");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.CatDirecciones)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cat_Direcciones_MtoCat_Usuarios");
            });

            modelBuilder.Entity<CatEditorial>(entity =>
            {
                entity.HasKey(e => e.Ideditorial);

                entity.ToTable("Cat_Editorial");

                entity.Property(e => e.Ideditorial).HasColumnName("IDEditorial");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatEstados>(entity =>
            {
                entity.HasKey(e => e.Idestado);

                entity.ToTable("Cat_Estados");

                entity.Property(e => e.Idestado).HasColumnName("IDEstado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CatEstadosMunicipios>(entity =>
            {
                entity.HasKey(e => e.IdestadoMunicipio);

                entity.ToTable("Cat_EstadosMunicipios");

                entity.Property(e => e.IdestadoMunicipio).HasColumnName("IDEstadoMunicipio");

                entity.Property(e => e.Idestado).HasColumnName("IDEstado");

                entity.Property(e => e.Idmunicipio).HasColumnName("IDMunicipio");

                entity.HasOne(d => d.IdestadoNavigation)
                    .WithMany(p => p.CatEstadosMunicipios)
                    .HasForeignKey(d => d.Idestado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cat_EstadosMunicipios_Cat_Estados");

                entity.HasOne(d => d.IdmunicipioNavigation)
                    .WithMany(p => p.CatEstadosMunicipios)
                    .HasForeignKey(d => d.Idmunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cat_EstadosMunicipios_Cat_Municipios");
            });

            modelBuilder.Entity<CatMunicipios>(entity =>
            {
                entity.HasKey(e => e.Idmunicipio);

                entity.ToTable("Cat_Municipios");

                entity.Property(e => e.Idmunicipio).HasColumnName("IDMunicipio");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(128)
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

                entity.Property(e => e.Sinopsis)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

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

            modelBuilder.Entity<MtoCatUsuarios>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK_MtoCat_Usuario");

                entity.ToTable("MtoCat_Usuarios");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TraCompras>(entity =>
            {
                entity.HasKey(e => e.Idcompra);

                entity.ToTable("Tra_Compras");

                entity.Property(e => e.Idcompra).HasColumnName("IDCompra");

                entity.Property(e => e.FechaCompra).HasColumnType("datetime");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.PrecioTotal).HasColumnType("money");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TraCompras)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tra_Compras_MtoCat_Usuario");
            });

            modelBuilder.Entity<TraConceptoCompra>(entity =>
            {
                entity.HasKey(e => e.TraCompras);

                entity.ToTable("Tra_ConceptoCompra");

                entity.Property(e => e.TraCompras).HasColumnName("Tra_Compras");

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
