using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    internal class ServicesContext : DbContext
    {
        public ServicesContext()
        {

        }

        public DbSet<AirportReservatie> AirportReservaties { get; set; }
        public DbSet<BusinessReservatie> BusinessReservatie { get; set; }
        public DbSet<NightLifeReservatie> NightLifeReservaties { get; set; }
        public DbSet<WeddingReservatie> WeddingReservaties { get; set; }
        public DbSet<WellnessReservatie> WellnessReservaties { get; set; }
        public DbSet<Limosine> Limosines { get; set; }
        public DbSet<Klant> Klanten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-353R5D9A\\SQLEXPRESS;Initial Catalog=ServicesRudyDB;Integrated Security=True");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Reservatie>().ToTable("Reservatie");
        //}
    }
} 
