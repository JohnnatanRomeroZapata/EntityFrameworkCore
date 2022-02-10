using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModels.Models.FluentValidation
{
    public class FluentBookDetail
    {
        public int Id { get; set; }

        public int NumberOfChapters { get; set; }

        public int NumberOfPages { get; set; }

        public FluentBook FluentBook { get; set; }
    }
}
