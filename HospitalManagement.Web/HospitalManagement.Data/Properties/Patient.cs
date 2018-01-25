using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
   public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public string History { get; set; }

        public string Diagnosis { get; set; }
        public string DiagnosisBy { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AdmitDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public string RefferedByDoctor { get; set; }
        
        public string AssingedDoctor { get; set; }

        public string MedicineHistory { get; set; }

        public string MedicineGivenBy { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

    }
}
