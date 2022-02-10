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
    public class FluentBookConfiguration : IEntityTypeConfiguration<FluentBook>
    {
        public void Configure(EntityTypeBuilder<FluentBook> builder)
        {
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(5);
            builder.Property(b => b.Price).IsRequired();

            //One to One
            builder.HasOne(b => b.FluentBookDetail).WithOne(bd => bd.FluentBook).HasForeignKey<FluentBook>(b => b.FluentBookDetailId);
            
            //One to Many
            builder.HasOne(b => b.FluentPublisher).WithMany(p => p.FluentBooks).HasForeignKey(b => b.FluentPublisherId);            
        }
    }
}
