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

              .ToTable("Pote")
              .HasKey("IDPote");

            modelBuilder.Entity<PotePais>()
            .Property(f => f.IDPote)
            .HasColumnName("ID")
            .HasColumnType("INT")
            .IsRequired();


            modelBuilder.Entity<PotePais>()
           .Property(f => f.IDPais)
           .HasColumnName("ID")
           .HasColumnType("INT")
           .IsRequired();












            base.OnModelCreating(modelBuilder);
        }

    }
}
