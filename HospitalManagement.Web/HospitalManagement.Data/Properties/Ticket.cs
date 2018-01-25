using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

       

        public int SerialNumber { get; set; }

        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public Building Building { get; set; }

        public int Ticket_CounterId { get; set; }
        public int Ticket_CounterNumber { get; set; }
        public Ticket_Counter Ticket_Counter { get; set; }
        
        [Required]
        public string PatientName { get; set; }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public Department Department { get; set; }


        public int Price { get; set; }

        public DateTime IssuedTime { get; set; }
        public string IssuedBy { get; set; }

    }
}
