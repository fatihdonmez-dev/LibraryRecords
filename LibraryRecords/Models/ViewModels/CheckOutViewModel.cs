namespace LibraryRecords.Models.ViewModels
{
    public class CheckOutViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DueDate { get; set; }
        public string TCKN { get; set; }
    }
}
