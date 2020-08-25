using DomainLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ServicesContext : DbContext
    {
        public ServicesContext()
        {

        }

        public virtual DbSet<Reservatie> Reservaties { get; set; }
        public virtual DbSet<Limosine> Limosines { get; set; }
        public virtual DbSet<Klant> Klanten { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-353R5D9A\\SQLEXPRESS;Initial Catalog=ServicesRudyDB;Integrated Security=True");
            //optionsBuilder.UseSqlServer("Data Source=LAPTOP-353R5D9A\\SQLEXPRESS;Initial Catalog=RudyTest;Integrated Security=True");
        }
    }
} 
