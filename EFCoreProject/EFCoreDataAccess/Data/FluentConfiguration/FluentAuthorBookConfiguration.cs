using EFCoreModels.Models.FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDataAccess.Data.FluentConfiguration
{
    public class FluentAuthorBookConfiguration : IEntityTypeConfiguration<FluentAuthorBook>
    {
        public void Configure(EntityTypeBuilder<FluentAuthorBook> builder)
        {
            builder.HasKey(ab => new { ab.AuthorId, ab.BookId });

            //Many to Many
            builder.HasOne<FluentAuthor>(ab => ab.FluentAuthor)
                .WithMany(a => a.FluentAuthorsBooks).HasForeignKey(ab => ab.AuthorId);
            builder.HasOne<FluentBook>(ab => ab.FluentBook)
                .WithMany(a => a.FluentAuthorsBooks).HasForeignKey(ab => ab.BookId);
        }
    }
}
