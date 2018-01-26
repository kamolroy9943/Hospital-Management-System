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
       public DbSet<ICU> Icu { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<Lab> Labs { get; set; }
        public DbSet<OperationTheater> OpertionTheaters { get; set; }
        public DbSet<Seat>Seats { get; set; }
        public DbSet<Ticket_Counter>TicketCounter { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Staff_Category> StaffCategory { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Building>().HasMany(x=>x.Departments).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.Ticket_Counter).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.Labs).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.Seats).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.Icu).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.Tickets).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.Wards).WithRequired(f => f.Building).WillCascadeOnDelete(false);
            modelBuilder.Entity<Building>().HasMany(x => x.OperationTheaters).WithRequired(f => f.Building).WillCascadeOnDelete(false);

            modelBuilder.Entity<Floor>().HasMany(x => x.Wards).WithRequired(f => f.Floor).WillCascadeOnDelete(false);
            modelBuilder.Entity<Floor>().HasMany(x => x.Rooms).WithRequired(f => f.Floor).WillCascadeOnDelete(false);
            modelBuilder.Entity<Floor>().HasMany(x => x.Labs).WithRequired(f => f.Floor).WillCascadeOnDelete(false);
            modelBuilder.Entity<Floor>().HasMany(x => x.Seats).WithRequired(f => f.Floor).WillCascadeOnDelete(false);
            modelBuilder.Entity<Floor>().HasMany(x => x.OperationTheaters).WithRequired(f => f.Floor).WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>().HasMany(x => x.Tickets).WithRequired(f => f.Department).WillCascadeOnDelete(false);

            
            base.OnModelCreating(modelBuilder);

        }

        
    }
}