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
    public class FluentAuthorConfiguration : IEntityTypeConfiguration<FluentAuthor>
    {
        public void Configure(EntityTypeBuilder<FluentAuthor> builder)
        {
            builder.Property(a => a.Name).IsRequired();
        }
    }
}
