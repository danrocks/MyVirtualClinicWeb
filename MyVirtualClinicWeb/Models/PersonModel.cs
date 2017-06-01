using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyVirtualClinicWeb.Models
{

    public class PersonModel
    {
        [Key]
        public int PersonModelId { get; set; }

        public string Firstname { get; set; }

        public string Surname { get; set; }

        public DateTime Dob { get; set; }

        [ForeignKey("VirtualClinicSubmissionModel")]
        public int SubmissionId { get; set; }

        public virtual VirtualClinicSubmissionModel VirtualClinicSubmissionModel { get; set; }
    }
}