namespace LibraryRecords.Models
{
    public class LibraryTransaction
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ActualReturnDate { get; set; }
        public decimal LateFee { get; set; }
        public bool IsCheckedOut { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string TCKN { get; set; }
        public Book Book { get; set; }

    }
}
