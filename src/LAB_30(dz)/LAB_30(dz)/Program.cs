
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LAB_30(dz)
{
{
    // Базовий клас користувача
    public abstract class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }

    // Читач
    public class Reader : User
    {
        public ICollection<Borrowing> Borrowings { get; set; }
    }

    // Працівник бібліотеки
    public class LibraryWorker : User
    {
        public string Position { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }

    // Книга
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public ICollection<Borrowing> Borrowings { get; set; }
    }

    // Позика книги
    public class Borrowing
    {
        public int Id { get; set; }
        public DateTime BorrowDate { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }

    public class LibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<LibraryWorker> LibraryWorkers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrowing> Borrowings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Наслідування TPH (Table-Per-Hierarchy)
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<Reader>("Reader")
                .HasValue<LibraryWorker>("LibraryWorker");

            // Ключі
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Borrowing>().HasKey(b => b.Id);

            // Зв'язки Borrowing -> Book
            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.Book)
                .WithMany(bk => bk.Borrowings)
                .HasForeignKey(b => b.BookId);

            // Зв'язки Borrowing -> User (Reader або LibraryWorker)
            modelBuilder.Entity<Borrowing>()
                .HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);
        }
    }
}