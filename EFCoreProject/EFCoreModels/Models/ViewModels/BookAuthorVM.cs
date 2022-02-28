using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModels.Models.ViewModels
{
    public class BookAuthorVM
    {
        public Book Book { get; set; }

        public Author Author { get; set; }

        public IEnumerable<SelectListItem> AuthorList { get; set; }
    }
}
