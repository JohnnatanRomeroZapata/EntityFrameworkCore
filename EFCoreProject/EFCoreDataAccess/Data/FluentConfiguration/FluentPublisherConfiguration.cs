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
    public class FluentPublisherConfiguration : IEntityTypeConfiguration<FluentPublisher>
    {
        public void Configure(EntityTypeBuilder<FluentPublisher> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
