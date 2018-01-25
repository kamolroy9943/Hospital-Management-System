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

        public string MedicineHistory { get; set; }
        public string MedicineUpadatedBy { get; set; }

        
    }
}
