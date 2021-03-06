﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.DataAccessLayer.Models.Enums;

namespace System.DataAccessLayer.Models.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(a => a.Name).HasColumnType("nvarchar(60)");//.HasMaxLength(60);
            builder.Property(a => a.Surname).HasColumnType("nvarchar(80)");//.HasMaxLength(80);
            builder.Property(a => a.Username).HasColumnType("nvarchar(50)");
            builder.Property(a => a.Password).HasColumnType("nvarchar(50)");
            builder.Property(a => a.NationId).HasMaxLength(10);
            builder.Property(a => a.UserType).HasConversion(
                v => v.ToString(),
                v => (UserType)Enum.Parse(typeof(UserType), v));
            //var client = new Client()
            //{
            //    Id = Guid.NewGuid(),
            //    Email = "s.ramezani@enb.ir",
            //    Mobile = "+989125449379",
            //    Phone = "+982156379337",
            //    Name = "Eagel Agency",
            //    Wallet_NO = "5859831036498060"
            //};
            //builder.HasData(new User()
            //{
            //    //Client = client,
            //    Id = Guid.NewGuid(),
            //    Name = "Sajad",
            //    Surname = "Ramezani",
            //    NationId = "5560021784",
            //    UserType = UserType.Developer,
            //    Username = "sajad91",
            //    Password = "qt!99!s@j@d",
            //    ClientId = client.Id
            //});
            //builder.HasData(new User()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Sajad",
            //    Surname = "Ramezani",
            //    NationId = "5560021784",
            //    UserType = UserType.Developer,
            //    Username = "sajad91",
            //    Password = "qt!99!s@j@d"
            //});
        }
    }
}
