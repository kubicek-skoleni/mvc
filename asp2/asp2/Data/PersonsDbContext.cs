﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class PersonsDbContext : DbContext
    {
        public PersonsDbContext()
        {
        }

        public PersonsDbContext(DbContextOptions<PersonsDbContext> options)
            : base(options)
        {
        }
         
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }

        public DbSet<LogRequest> LogRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-MVCIS-0E5D8AF6-1B19-4FEC-948C-5A4131216F32;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=dbextract2;Integrated Security=true");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}