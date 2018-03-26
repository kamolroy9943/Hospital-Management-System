using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public string WhatFor { get; set; }
        public string Description { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public int Amount { get; set; }

         

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public Patient Patient { get; set; }
    }
}
