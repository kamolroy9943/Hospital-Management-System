using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data
{
   public class AdminRole
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string IsBlocked { get; set; }

        public string IsAssigned { get; set; }

        public int BuildingId { get; set; }
        public int PostId { get; set; }

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
