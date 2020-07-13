using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.DataAccessLayer.Models.Configurations
{
    public class FileConfigurations : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.Property(a => a.Title).HasMaxLength(150).ValueGeneratedOnAdd().IsRequired();
            builder.Property(a => a.FileExtension).HasMaxLength(10).IsRequired();
            builder.Property(a => a.CreateDateTime).HasDefaultValueSql("GetDate()");
            builder.Property(a => a.LastModified).HasDefaultValueSql("GetDate()");
        }
    }
}
