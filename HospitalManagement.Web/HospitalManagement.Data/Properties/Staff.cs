using System;
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

        public string Contact { get; set; }
        public string ContactNo { get; set; }
        public string ContactEmail { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public string Designation { get; set; }

        [DataType(DataType.Date)]
        public DateTime joinningDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime RetireDate { get; set; }

        [Required]
        public string IssuedBy { get; set; }

        
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

}
}
