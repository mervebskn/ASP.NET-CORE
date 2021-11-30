using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeManagement.Models
{
    public class Experience
    {
        public Experience()
        {

        }
        [Key]
        public int ExperienceId { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int YearWorked { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; set; }
    }
}
