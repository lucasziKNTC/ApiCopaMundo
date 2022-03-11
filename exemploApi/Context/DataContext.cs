using Microsoft.EntityFrameworkCore;
using exemploApi.Models;

namespace exemploApi.Context
{
    public class DataContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var conn = @"Data source = 201.62.57.93;  
                                    Database = BD040161; 
                                    User ID = RA040161;  
                                    Password = 040161";
            optionsBuilder.UseSqlServer(conn);
        }

        
        public DbSet<Confederacao> Confederacao { get; set; }

        public DbSet<Paises> Paises { get; set; }

        public DbSet<Pote> Pote { get; set; }

        public DbSet<PotePais> PotePais { get; set; }

        public DbSet<Grupos> Grupos { get; set; }

        public DbSet<Participantes> Participantes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("COPADOMUNDO");

            ///////////////////////////////////////////////////////////

            modelBuilder.Entity<Confederacao>()
               
                .ToTable("Confederacao" )
                
                .HasKey("IDConfederacao");

            modelBuilder.Entity<Confederacao>()
                .Property(f => f.IDConfederacao)
                .HasColumnName("ID")
                .HasColumnType("INT")
                .IsRequired();

            modelBuilder.Entity<Confederacao>()
                .Property(f => f.Nome)
                .HasColumnName("NOME")
                .HasColumnType("varchar(50)")
                .IsRequired();

            modelBuilder.Entity<Confederacao>()
                .Property(f => f.Sigla)
                .HasColumnName("SIGLA")
                .HasColumnType("varchar(10)")
                .IsRequired();

            //////////////////////////////////////////////


            modelBuilder.Entity<Paises>()

               .ToTable("Paises")
               .HasKey("ID");

            modelBuilder.Entity<Paises>()
              .Property(f => f.ID)
              .HasColumnName("ID")
              .HasColumnType("INT")
              .IsRequired();

            modelBuilder.Entity<Paises>()
           .Property(f => f.RankingFifa)
           .HasColumnName("RANKINGFIFA")
           .HasColumnType("INT")
           .IsRequired();

            modelBuilder.Entity<Paises>()
           .Property(f => f.Participantes)
           .HasColumnName("NOME")
           .HasColumnType("VARCHAR(50)")
           .IsRequired();


            modelBuilder.Entity<Paises>()
           .Property(f => f.Sede)
           .HasColumnName("SEDE")
           .HasColumnType("BIT")
           .IsRequired();


            modelBuilder.Entity<Paises>()
           .Property(f => f.IdConfederacao)
           .HasColumnName("IDCONFEDERACAO")
           .HasColumnType("int")
           .IsRequired();



            modelBuilder.Entity<Paises>()
                .HasOne(f => f.confederacao)
                .WithMany()
                .HasForeignKey(f => f.IdConfederacao);

            /////////////////////////////////////////////////


            modelBuilder.Entity<Pote>()

               .ToTable("Pote")
               .HasKey("IDPote");
            
            modelBuilder.Entity<Pote>()
              .Property(f => f.IDPote)
              .HasColumnName("ID")
              .HasColumnType("INT")
              .IsRequired();

            modelBuilder.Entity<Pote>()
           .Property(f => f.Descricao)
           .HasColumnName("DESCRICAO")
           .HasColumnType("VARCHAR(50)")
           .IsRequired();


            ///////////////////////////


            modelBuilder.Entity<PotePais>()
                .HasNoKey()
               .ToTable("PotePais");
              


            modelBuilder.Entity<PotePais>()
            .Property(f => f.IDPote)
            .HasColumnName("IDPOTE")
            .HasColumnType("INT")
            .IsRequired();


            modelBuilder.Entity<PotePais>()
           .Property(f => f.IDPais)
           .HasColumnName("IDPAIS")
           .HasColumnType("INT")
           .IsRequired();


            modelBuilder.Entity<PotePais>()
                .HasOne(f => f.Paises)
                .WithMany()
                .HasForeignKey(f => f.IDPais);

            modelBuilder.Entity<PotePais>()
                .HasOne(f => f.Pote)
                .WithMany()
                .HasForeignKey(f => f.IDPote);


            /////////////////////////////////////

            modelBuilder.Entity<Grupos>()

              .ToTable("Grupos")
              .HasKey("IDGrupo");

            modelBuilder.Entity<Grupos>()
              .Property(f => f.IDGrupo)
              .HasColumnName("IDGrupo")
              .HasColumnType("INT")
              .IsRequired();

            modelBuilder.Entity<Grupos>()
              .Property(f => f.Nome)
              .HasMaxLength(16)
              .HasColumnName("Nome")
              .HasColumnType("VARCHAR")
              .IsRequired();

            //////////////////////////////////
            modelBuilder.Entity<Participantes>()

             .ToTable("Participantes")
             .HasKey("IDPais");

            modelBuilder.Entity<Participantes>()
              .Property(f => f.IDPais)
              .HasColumnName("IDPais")
              .HasColumnType("INT")
              .IsRequired();

            modelBuilder.Entity<Participantes>()
              .Property(f => f.IDGrupo)
              .HasColumnName("IDGrupo")
              .HasColumnType("INT")
              .IsRequired();

            modelBuilder.Entity<Participantes>()
              .Property(f => f.Participante)
              .HasMaxLength(50)
              .HasColumnName("Participantes")
              .HasColumnType("VARCHAR")
              .IsRequired();

            base.OnModelCreating(modelBuilder);
        }

    }
}
