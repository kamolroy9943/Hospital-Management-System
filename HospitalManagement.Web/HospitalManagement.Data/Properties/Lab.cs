using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
    public class Lab
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public int BuildingId { get; set; }
        public string BuildingName{get;set;}
        public Building Building { get; set; }

        public int FloorId { get; set; }
        public int FloorNumber { get; set; }
        public Floor Floor { get; set; }

        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public Room Room { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        //public IList<Building>Building { get; set; }

        //public IList<Floor>Floor { get; set; }
       
    }
}
