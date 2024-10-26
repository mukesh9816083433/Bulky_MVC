﻿
using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
                 
        } 
        //for creating table in the database we make DbSet
        public DbSet<Category> Categories { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
          //modelBuilder.Entity<Category>().HasData(
            //  new Category { Id=1, Name="Action",DisplayOrder=1},
            //  new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
            //  new Category { Id = 3, Name = "History", DisplayOrder = 3 }
             //  );
        // }


    }
}
