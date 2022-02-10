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
    public class FluentBookDetailConfiguration : IEntityTypeConfiguration<FluentBookDetail>
    {
        public void Configure(EntityTypeBuilder<FluentBookDetail> builder)
        {
            builder.Property(bd => bd.NumberOfPages).IsRequired();
            builder.Property(bd => bd.NumberOfChapters).IsRequired();
        }
    }
}
