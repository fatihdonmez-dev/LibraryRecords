namespace LibraryRecords.Models.ViewModels
{
    public class ChechInViewModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
