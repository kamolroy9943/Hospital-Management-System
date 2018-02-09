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

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public Patient Patient { get; set; }

        public string Doctors_Checked { get; set; }
        public string Medicine { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
       

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
