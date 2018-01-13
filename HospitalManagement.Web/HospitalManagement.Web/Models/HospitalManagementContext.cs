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
    }
}