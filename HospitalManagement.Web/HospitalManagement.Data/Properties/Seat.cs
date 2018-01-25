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
        public string IsEmpty { get; set; } // Is there is any patient assinged 

        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public Building Building { get; set; }

        public int FloorId { get; set; }
        public int FloorNumber { get; set; }
        public Floor Floor { get; set; }

        public string Where { get; set; } // Where is the Seat Is ? In Ward Or In a Room 
        public int WhereID { get; set; } // For WardID or For Room Id

        public int HasbeenUsed { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }

        //..............
       // public Patient Patient { get; set; }

        //public IList<Ward>Ward { get; set; }

        //public IList<Room> Room { get; set; }
    }
}
