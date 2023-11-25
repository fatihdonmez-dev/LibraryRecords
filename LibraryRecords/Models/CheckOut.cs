namespace LibraryRecords.Models
{
    public class CheckOut
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string PersonName { get; set; }
        public string PhoneNumber { get; set; }
        public string TCKN { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public decimal PenaltyAmount { get; set; }
    }
}
