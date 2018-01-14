using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using HospitalManagement.Data;

namespace HospitalManagement.Web.Models
{
    public class HospitalManagementContext : DbContext
    {

        public DbSet<Building> Building { get; set; }

        public DbSet<Floor> Floors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Ward> Wards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasMany(x=>x.Departments).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.Rooms).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.Wards).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Floor>().HasMany(x => x.Wards).WithRequired(f => f.Floor).WillCascadeOnDelete(false);
            modelBuilder.Entity<Floor>().HasMany(x => x.Rooms).WithRequired(f => f.Floor).WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

        }
    }
}