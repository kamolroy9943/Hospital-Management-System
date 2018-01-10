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

        [Required]
        public string PatientName { get; set; }

        public Department DepartmentName { get; set; }

        public Room RoomNumber { get; set; }

        public DateTime Date { get; set; }

        public int Price { get; set; }

        public string IssuedBy { get; set; }

    }
}
