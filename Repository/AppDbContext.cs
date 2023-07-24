using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookReader> Readers { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if(!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("SqlConnection");
        //    }
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasOne(b => b.Category).WithMany(q => q.Books).HasForeignKey(a => a.CategoryId);
            modelBuilder.Entity<BookReader>().HasMany(w => w.ReadedBooks).WithMany(a => a.Readers).UsingEntity(z => z.ToTable("ReadersBooks"));
        }
    }
}