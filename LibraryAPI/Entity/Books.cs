using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Entity
{
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string ISBN { get; set; }
        [ForeignKey("Authors")]
        public int AuthorID { get; set; }
        public int AvailableCopies { get; set; }
        public int TotalCopies { get; set; }
        [JsonIgnore]
        public Authors? Authors { get; set; }
    }
}
