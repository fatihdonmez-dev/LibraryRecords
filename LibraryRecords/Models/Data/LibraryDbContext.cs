using Microsoft.EntityFrameworkCore;

namespace LibraryRecords.Models.Data
{

    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<LibraryTransaction> LibraryTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryTransaction>()
            .HasOne(lt => lt.Book)
            .WithMany(b => b.Transactions)
            .HasForeignKey(lt => lt.BookId);

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();

            modelBuilder.Entity<LibraryTransaction>()
                .Property(p => p.TCKN)
                .HasMaxLength(11);

            modelBuilder.Entity<LibraryTransaction>()
                .Property(lt => lt.IsCheckedOut)
                .HasDefaultValue(false);
        }

        internal object Find(int ıd)
        {
            throw new NotImplementedException();
        }
    }

}
