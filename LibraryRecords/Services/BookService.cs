using LibraryRecords.Models;
using LibraryRecords.Models.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryRecords.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAllBooks()
        {
            var response = _context.Books.Include(b => b.Transactions).ToList();
            return response;
        }

        public Book GetBook(int id)
        {
            var book = _context.Books.Include(b => b.Transactions).FirstOrDefault(x=> x.Id == id);
            return book;
        }

        public int SaveBook(Book book)
        {
            _context.Books.Update(book);
            return _context.SaveChanges();
        }
    }
}
