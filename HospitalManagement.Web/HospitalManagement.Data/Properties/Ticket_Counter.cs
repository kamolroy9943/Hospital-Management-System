using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Ticket_Counter 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        

    }
}
