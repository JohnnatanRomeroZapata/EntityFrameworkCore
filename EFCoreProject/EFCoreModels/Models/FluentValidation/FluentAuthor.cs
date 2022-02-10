﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreModels.Models.FluentValidation
{
    public class FluentAuthor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Location { get; set; }

        public ICollection<FluentAuthorBook> FluentAuthorsBooks { get; set; }
    }
}