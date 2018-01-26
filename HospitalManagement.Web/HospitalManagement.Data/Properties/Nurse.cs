using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
   public class Nurse: Staff
    {
        [Key]
        public int NurseId { get; set; }

        [Required]
        public string Post { get; set; }
}
}
