using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModels.Models
{
    public class BookDetail
    {
        public int Id { get; set; }

        public int NumberOfChapters { get; set; }

        public int NumberOfPages { get; set; }

        public Book Book { get; set; }
    }
}
