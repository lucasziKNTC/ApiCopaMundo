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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            ///////////////////////////////////////////////////////////

            modelBuilder.Entity<Confederacao>()
                .ToTable("Confederacao" )
                .HasKey("IdConfederacao");

            modelBuilder.Entity<Confederacao>()
                .Property(f => f.IDConfederacao)
                .HasColumnName("ID")
                .HasColumnType("tinyint")
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

            base.OnModelCreating(modelBuilder);
        }

    }
}
