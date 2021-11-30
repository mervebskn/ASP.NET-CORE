using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeManagement.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        public string Gender { get; set; }
        [Required]
        public string Qualification { get; set; }
        public int TotalExperience { get; set; }
        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();
    }
}
