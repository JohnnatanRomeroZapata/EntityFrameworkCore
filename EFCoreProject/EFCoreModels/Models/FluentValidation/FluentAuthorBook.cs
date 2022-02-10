using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModels.Models.FluentValidation
{
    public class FluentAuthorBook
    {
        public int BookId { get; set; }
        public FluentBook FluentBook { get; set; }

        public int AuthorId { get; set; }
        public FluentAuthor FluentAuthor { get; set; }
    }
}
