using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
     public class Treatment
    {
        [Key]
        public int Id { get; set; }

        public string Doctors_Checked { get; set; }
        public string Medicine { get; set; }
        public DateTime Date { get; set; }
    }
}
