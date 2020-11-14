using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyPlusApp.Models
{
    public class PropertyLeaser
    {
        public PropertyLeaser()
        {
            Property = new HashSet<Property>();
        }

        [Key]
        public int LeaserId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid emaild address")]
        [Required(ErrorMessage = "Email-Id is required.")]
        public string Email { get; set; }

     
        [Required(ErrorMessage = "Street address is required.")]
        public string Address { get; set; }


        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]        
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is required.")]
        public int? ZipCode { get; set; }
        public string Comments { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Property> Property { get; set; }

    }
}
