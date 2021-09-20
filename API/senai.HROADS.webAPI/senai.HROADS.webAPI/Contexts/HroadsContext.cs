using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using senai.HROADS.webAPI.Domains;

#nullable disable

namespace senai.HROADS.webAPI.Contexts
{
    public partial class HroadsContext : DbContext
    {
        public HroadsContext()
        {
        }

        public HroadsContext(DbContextOptions<HroadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<ConClasseHab> ConClasseHabs { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Data Source=PEDRO-PC\\SQLEXPRESS; initial catalog=SENAI_HROADS_TARDE; user Id=sa; pwd=senai@123;");
                optionsBuilder.UseSqlServer(@"Server=PEDRO-PC\SQLEXPRESS; DataBase=SENAI_HROADS_TARDE; user Id=sa; pwd=senai@123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity =>
            {
                entity.HasKey(e => e.IdClasse)
                    .HasName("PK__Classe__0652AF79424CCB4E");

                entity.ToTable("Classe");

                entity.Property(e => e.IdClasse).ValueGeneratedOnAdd();

                entity.Property(e => e.NomeClasse)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConClasseHab>(entity =>
            {
                entity.HasKey(e => e.IdConClasseHab)
                    .HasName("PK__ConClass__0E303797AA8C7023");

                entity.ToTable("ConClasseHab");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.ConClasseHabs)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__ConClasse__IdCla__787EE5A0");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.ConClasseHabs)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK__ConClasse__IdHab__797309D9");
            });

            modelBuilder.Entity<Habilidade>(entity =>
            {
                entity.HasKey(e => e.IdHabilidade)
                    .HasName("PK__Habilida__0DD4B30D6407E3CE");

                entity.ToTable("Habilidade");

                entity.Property(e => e.IdHabilidade).ValueGeneratedOnAdd();

                entity.Property(e => e.NomeHabilidade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK__Habilidad__IdTip__75A278F5");
            });

            modelBuilder.Entity<Personagem>(entity =>
            {
                entity.HasKey(e => e.IdPersonagem)
                    .HasName("PK__Personag__4C5EDFB3FF975D39");

                entity.ToTable("Personagem");

                entity.HasIndex(e => e.NomePersonagem, "UQ__Personag__84C7E40CD6172F8A")
                    .IsUnique();

                entity.Property(e => e.IdPersonagem).ValueGeneratedOnAdd();

                entity.Property(e => e.DataCriacao).HasColumnType("date");

                entity.Property(e => e.DataUpdate).HasColumnType("date");

                entity.Property(e => e.NomePersonagem)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK__Personage__IdCla__5FB337D6");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Personage__IdUsu__7C4F7684");
            });

            modelBuilder.Entity<TipoHabilidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoHab)
                    .HasName("PK__TipoHabi__3D2B5C7C99A85E90");

                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.IdTipoHab).ValueGeneratedOnAdd();

                entity.Property(e => e.NomeTipoHab)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TipoUsua__CA04062B793FE45C");

                entity.ToTable("TipoUsuario");

                entity.HasIndex(e => e.TituloTipoUsuario, "UQ__TipoUsua__37BBE07E9CFCA9CB")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario).ValueGeneratedOnAdd();

                entity.Property(e => e.TituloTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97313E3F23");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105340C88EDBE")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__Usuario__IdTipoU__6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
