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

        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public Building Building { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

    }
}
