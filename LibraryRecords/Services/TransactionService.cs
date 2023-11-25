using LibraryRecords.Models;
using LibraryRecords.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryRecords.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly LibraryDbContext _context;

        public TransactionService(LibraryDbContext context)
        {
            _context = context;
        }

        public int AddTransaction(LibraryTransaction transaction)
        {
            _context.LibraryTransactions.Add(transaction);
            return _context.SaveChanges();
        }

        public List<LibraryTransaction> GetAllTransaction()
        {
            var response = _context.LibraryTransactions.ToList();
            return response;
        }

        public LibraryTransaction GetTransaction(int id)
        {
            var response = _context.LibraryTransactions.Find(id);
            return response;
        }

        public int SaveTransaction(LibraryTransaction transaction)
        {
            _context.LibraryTransactions.Update(transaction);
            return _context.SaveChanges();
        }
    }
}
