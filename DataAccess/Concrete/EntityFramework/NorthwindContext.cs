using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    /// <summary>
    /// Context: Db tabloları ile proje classlarını bağlamak.
    /// </summary>
    public class NorthwindContext:DbContext
    {
        /// <summary>
        /// projenin hangi db ile ilişkilendirileceğinin bulunduğu yer.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Mapping örneği: veritabanında bu isimde tablo yok.
        /// </summary>
        public DbSet<Personel> Personels { get; set; }

        /// <summary>
        /// FLUENT MAPPING!....
        /// mapping için override edildi. default shema dbo yu kullandı. farklı şemalar da verebiliriz.
        /// Admin vb yetkiye sahip özel kullanıcıların erişimleri de bu şekilde tanımlana bilinir.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity("admin");

            //TABLO
            modelBuilder.Entity<Personel>().ToTable("Employees");
            //Entities
            modelBuilder.Entity<Personel>().Property(p => p.Id).HasColumnName("EmployeeId");
            modelBuilder.Entity<Personel>().Property(p => p.Name).HasColumnName("FirstName");
            modelBuilder.Entity<Personel>().Property(p => p.Surname).HasColumnName("LastName");
        }
    }
}
