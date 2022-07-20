using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using Clearence.Models.Enums;

namespace Clearence.Models
{
    public class StudentViewModel
    {
        public string RegistrationNumber { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string Course { get; set; }
        public string Department { get; set; }
        public int Gender { get; set; }
    }
}