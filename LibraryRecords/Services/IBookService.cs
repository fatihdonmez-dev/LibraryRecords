using LibraryRecords.Models;

namespace LibraryRecords.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBook(int id);
        int SaveBook(Book book);
    }
}
