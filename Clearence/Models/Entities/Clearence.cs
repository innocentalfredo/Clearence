using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clearence.Models.Entities
{
    public class Clearence
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public bool IsFinance { get; set; }
        public bool DeanOfStudent { get; set; }
        public bool IsRegistrar { get; set; }
        public string Comment { get; set; }
        [DataType(DataType.Date)]
        public DateTime ClearenceDate { get; set; }
        public virtual Student Student { get; set; }
    }
}