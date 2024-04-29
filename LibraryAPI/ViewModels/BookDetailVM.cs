namespace LibraryAPI.ViewModels
{
    public class BookDetailVM
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        public string AvailableCopies { get; set; }
    }
}
