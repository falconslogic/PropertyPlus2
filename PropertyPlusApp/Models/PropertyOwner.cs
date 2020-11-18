using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyPlusApp.Models
{
    public class PropertyOwner
    {
        public PropertyOwner()
        {
            Property = new HashSet<Property>();
        }

        [Key]
        public int OwnerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Not a valid entry")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Not a valid entry")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid emaild address")]
        [Required(ErrorMessage = "Email-Id is required.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Street address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Not a valid entry")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Not a valid entry")]
        public string State { get; set; }

        [Required(ErrorMessage = "Zipcode is required.")]
        public int? ZipCode { get; set; }
        public string Comments { get; set; }

        public string FullName {  get { return FirstName + " " + LastName; } }
        public virtual ICollection<Property> Property { get; set; }
    }
}
