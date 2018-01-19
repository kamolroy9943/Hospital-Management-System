using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Data.Properties
{
    public class ICU
    {
        [Key]
        public int Id { get; set; }

        public string ICUName { get; set; }

        public int BuildingId { get; set; }
        public Building Building {get;set;}

        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
    }
}
