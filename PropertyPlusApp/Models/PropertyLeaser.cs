﻿using System;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? ZipCode { get; set; }
        public string Comments { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Property> Property { get; set; }

    }
}