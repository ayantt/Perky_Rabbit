using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryAPI.Entity
{
    public class BorrowedBooks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int BorrowID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        [ForeignKey("Members")]
        public int MemberId { get; set; }
        [ForeignKey("Books")]
        public int BookId { get; set; }
        public string? Status { get; set; }
        [JsonIgnore]
        public Members? Members { get; set; }
        [JsonIgnore]
        public Books? Books { get; set; }
    }
}
