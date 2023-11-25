namespace LibraryRecords.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool IsCheckedOut { get; set; }
        public List<LibraryTransaction> Transactions { get; set; }
    }
}
