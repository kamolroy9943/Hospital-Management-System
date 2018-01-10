using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string RoomNumber { get; set; }

        public IList<Floor>Floor { get; set; }

        public ICollection<Seat> Seats { get; set; }
       
    }
}
