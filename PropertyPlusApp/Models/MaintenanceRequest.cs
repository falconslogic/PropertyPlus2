using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyPlusApp.Models
{
    public class MaintenanceRequest
    {
        [Key]
        public int MaintenanceId { get; set; }
        public int PropertyId { get; set; }

        [Required]
        public string Description { get; set; }
        public string Documents { get; set; }

        [Required]
        public string Priority { get; set; }

        public virtual Property Property { get; set; }

    }
}
