using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        public int Number { get; set; }

        [Required]
        public bool Isempty { get; set; }


        //..............
        public Patient Patient { get; set; }

        public IList<Ward>Ward { get; set; }

        public IList<Room> Room { get; set; }
    }
}
