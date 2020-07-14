using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace System.DataAccessLayer.Models.Configurations
{
    public class BaseInfoConfiguration : IEntityTypeConfiguration<BaseInfoModel>
    {
        public void Configure(EntityTypeBuilder<BaseInfoModel> builder)
        {
            builder.HasKey(a => a.Id);
            //builder.Property(a => a.Id).HasDefaultValueSql("NEWID()");
            builder.Property(a => a.IsActive).HasDefaultValueSql("1");
            builder.Property(a => a.CreateDate).HasDefaultValueSql("getdate()");
            //builder.HasData(new BaseInfoModel()
            //{
            //    Id = Guid.NewGuid()
            //});
        }
    }
}
