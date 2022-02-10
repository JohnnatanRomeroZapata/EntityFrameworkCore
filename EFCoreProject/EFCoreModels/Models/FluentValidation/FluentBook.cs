using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModels.Models.FluentValidation
{
    public class FluentBook
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public double Price { get; set; }

        public int FluentBookDetailId { get; set; }
        public FluentBookDetail FluentBookDetail { get; set; }

        public int FluentPublisherId { get; set; }
        public FluentPublisher FluentPublisher { get; set; }

        public ICollection<FluentAuthorBook> FluentAuthorsBooks { get; set; }
    }
}
