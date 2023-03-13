﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using NLayer.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> productFeatures { get; set; }
        // public DbSet<ProductFeature> productFeatures { get; set; } //Product üzerinden ekleme yapılabilir. 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new ProductConfiguration()); // yukarıdaki kod parçası hepsine uyguladı.
            base.OnModelCreating(modelBuilder);
        }


    }
}