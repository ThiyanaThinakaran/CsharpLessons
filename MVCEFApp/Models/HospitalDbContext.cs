using System;
using MVCEFApp.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MVCEFApp.Models
{
    public class HospitalDbContext: DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            String conString = @"server=200411LTP2776\SQLEXPRESS;database=HospitalDB;integrated security=true;Encrypt=false;";
            options.UseSqlServer(conString);
        }
    }
}
