using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyPlusApp.Models
{
    public class PaymentHistory
    {
        public PaymentHistory()
        {
            Property = new HashSet<Property>();
        }

        [Key]
        public int PaymentId { get; set; }

        [Display(Name = "Total Payments")]
        [Required]
        public int? TotalPayments { get; set; }

        [Display(Name = "Total Paid")]
        [Required]
        public int? TotalPaid { get; set; }

        [Display(Name = "Total Late")]
        [Required]
        public int? TotalLate { get; set; }

        [Display(Name = "Total Months")]
        [Required]
        public int? TotalMonths { get; set; }
        public virtual ICollection<Property> Property { get; set; }


    }
}
