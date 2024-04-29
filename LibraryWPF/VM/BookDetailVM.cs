using System;

namespace LibraryWPF.VM
{
    public class BookDetailVM
    {
        public int bookId { get; set; }
        public string title { get; set; }
        public string authorName { get; set; }
        public DateTime publishedDate { get; set; }
        public string isbn { get; set; }
        public string availableCopies { get; set; }
    }
}
