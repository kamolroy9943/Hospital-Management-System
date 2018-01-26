﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
   public class Staff
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string Designation { get; set; }

        [Required]
        public DateTime joinningDate { get; set; }

        public DateTime RetireDate { get; set; }

        [Required]
        public string IssuedBy { get; set; }

        public IList<Staff_Category> Staff_Category { get; set; }


}
}
