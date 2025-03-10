using LibraryManagementSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LibraryManagementSystem.Infrastructure.Persistence
{
    public class LibraryManagementSystemDbContext : DbContext
    {
        public LibraryManagementSystemDbContext(DbContextOptions<LibraryManagementSystemDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookLoan> BookLoan { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.
                Entity<Book>(e =>
                {
                    e.ToTable("tb_book");
                    e.HasKey(b => b.Id);

                    e.HasMany(b => b.Reviews)
                        .WithOne(r => r.Book)
                        .HasForeignKey(r => r.IdBook);

                    e.HasMany(b => b.BookLoans)
                        .WithOne(bl => bl.Book)
                        .HasForeignKey(bl => bl.IdBook);
                });

            builder.
                Entity<User>(e =>
                {
                    e.ToTable("tb_user");
                    e.HasKey(u => u.Id);

                    e.HasMany(u => u.BookLoans)
                        .WithOne(bl => bl.User)
                        .HasForeignKey(bl => bl.IdUser)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            builder.
                Entity<Review>(e =>
                {
                    e.ToTable("tb_review");
                    e.HasKey(r => r.Id);
                });
            builder.
                Entity<BookLoan>(e =>
                {
                    e.ToTable("tb_book_loan");
                    e.HasKey(bl => bl.Id);
                });

            builder
                .Entity<BookAuthor>(e =>
                {
                    e.ToTable("tb_book_author");
                    e.HasKey(ba => new { ba.IdBook, ba.IdAuthor });

                    e.HasOne(ba => ba.Author)
                        .WithMany(a => a.BookAuthors)
                        .HasForeignKey(ba => ba.IdAuthor);

                    e.HasOne(ba => ba.Book)
                        .WithMany(b => b.BookAuthors)
                        .HasForeignKey(ba => ba.IdBook);
                });


            base.OnModelCreating(builder);
        }
    }
}
