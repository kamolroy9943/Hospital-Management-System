using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public Patient Patient { get; set; }

        public string PayerName { get; set; }

        public string Paid { get; set; }
        public string Due { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

    }
}
