using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyPlusApp.Models
{
    public class Property
    {
        public Property()
        {
            MaintenanceRequest = new HashSet<MaintenanceRequest>();
        }

        [Key]
        public int PropertyId { get; set; }
        public int OwnerId { get; set; }
        public int LeaserId { get; set; }
        public byte[] Picture { get; set; }
        public string Address { get; set; }

        [Display(Name = "Sq ft")]
        public int? SquareFeet { get; set; }
        public int? Bedrooms { get; set; }
        public double? Baths { get; set; }
        public int? Year { get; set; }
        public string Features { get; set; }

        [Display(Name = "Monthly Rate")]
        public int? MonthlyRate { get; set; }
        public string Utilities { get; set; }

        [Display(Name = "Contract Time")]
        public string ContractTime { get; set; }
        public int PaymentId { get; set; }

        public virtual PropertyLeaser Leaser { get; set; }
        public virtual PropertyOwner Owner { get; set; }
        public virtual PaymentHistory Payment { get; set; }
        public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }
    }
}
