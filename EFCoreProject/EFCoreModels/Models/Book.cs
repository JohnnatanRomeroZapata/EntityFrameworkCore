using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFCoreModels.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public double Price { get; set; }

        public int? BookDetailId { get; set; }
        public BookDetail BookDetail { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
