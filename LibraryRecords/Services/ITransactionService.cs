using LibraryRecords.Models;

namespace LibraryRecords.Services
{
    public interface ITransactionService
    {
        List<LibraryTransaction> GetAllTransaction();
        LibraryTransaction GetTransaction(int id);
        int SaveTransaction(LibraryTransaction transaction);
        int AddTransaction(LibraryTransaction transaction);
    }
}
