using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using static System.DataAccessLayer.Models.Enums;

namespace System.DataAccessLayer.Models.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(a => a.Name).HasColumnType("nvarchar(60)");//.HasMaxLength(60);
            builder.Property(a => a.Phone).HasColumnType("nvarchar(20)");//.HasMaxLength(80);
            builder.Property(a => a.Mobile).HasColumnType("nvarchar(15)");
            builder.Property(a => a.Wallet_NO).HasColumnType("nvarchar(30)");
            //builder.HasData(new Client()
            //{
            //    Id = Guid.NewGuid(),
            //    Email = "s.ramezani@enb.ir",
            //    Mobile = "+989125449379",
            //    Phone = "+982156379337",
            //    Name = "Eagel Agency",
            //    Wallet_NO = "5859831036498060"
            //});
            var client = new Client()
            {
                Id = Guid.NewGuid(),
                Email = "s.ramezani@enb.ir",
                Mobile = "+989125449379",
                Phone = "+982156379337",
                Name = "Eagel Agency",
                Wallet_NO = "5859831036498060"
            };
            builder.HasData(new User()
            {
                Id = Guid.NewGuid(),
                Name = "Sajad",
                Surname = "Ramezani",
                NationId = "5560021784",
                UserType = UserType.Developer,
                Username = "sajad91",
                Password = "qt!99!s@j@d",
                ClientId = client.Id
            });
            builder.HasMany(a => a.Users).WithOne(a => a.Client).HasForeignKey("ClientId").IsRequired();

        }
    }
}
