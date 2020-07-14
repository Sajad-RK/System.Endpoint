﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace System.DataAccessLayer
{
    public class Entities : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HABIBI-MATIN;Database=StoreDB;user id=sajadramezani;password=123456");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Configurations
            builder.ApplyConfiguration(new Models.Configurations.FileConfigurations());
            builder.ApplyConfiguration(new Models.Configurations.UserConfiguration());
            //builder.ApplyConfiguration(new Models.Configurations.BaseInfoConfiguration());

            #endregion

        }
        public DbSet<Models.File> Files { get; set; }
        public DbSet<Models.User> Users { get; set; }
    }

}
