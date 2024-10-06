using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NetHomeWorksApp
{
    internal class BooksContext : DbContext
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Publisher> Publishers { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;

        public BooksContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BooksDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>()
                        .ToTable("Authors")
                        .HasIndex(b => new { b.Name, b.BirthDate })
                        .HasDatabaseName("IX_Name");
            //.HasIndex(b => b.Name);
            //.IsUnique();

            //modelBuilder.Entity<Author>()
                        //.ToTable(a => a.HasCheckConstraint("BirthDate", ""));

            modelBuilder.Entity<Author>()
                        .Property(a => a.Name)
                        .HasMaxLength(50)
                        .IsRequired()
                        .HasColumnName("Name");

            modelBuilder.Entity<Book>()
                        .HasOne(book => book.Author)
                        .WithMany(author => author.Books)
                        .OnDelete(DeleteBehavior.Cascade);
                        //.HasForeignKey(book => book.AuthorId);

            modelBuilder.Entity<Book>()
                        .HasOne(b => b.Publisher)
                        .WithMany(p => p.Books)
                        .OnDelete(DeleteBehavior.Cascade);
            //.HasForeignKey(b => b.PublisherId);


            modelBuilder.ApplyConfiguration(new PublisherConfiguration());

        }
    }
}
