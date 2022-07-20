using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Clearence.Models.Enums;

namespace Clearence.Models.Entities
{
    public class Student
    {
        public Student()
        {
            this.Clearences = new List<Clearence>();
        }
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Course { get; set; }
        public string Department { get; set; }
        public int Year { get; set; }
        public bool Iscomplete { get; set; }
        public bool IsFinance { get; set; }
        public bool DeanOfStudent { get; set; }
        public bool IsRegistrar { get; set; }

        public virtual ICollection<Clearence> Clearences { get; set; }
    }
}