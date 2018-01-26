﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Staff_Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

       public ICollection<Staff> staff { get; set; }
    }
}
