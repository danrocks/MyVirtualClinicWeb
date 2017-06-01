using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyVirtualClinicWeb.Models
{
    public class ImageModel
    {
        /// <summary>
        /// Foriegn key to submission id (in VirtualClinicSubmissionModel) that tthis image was submitted with.
        /// </summary>
        [Key]
        public int ImageModelId { get; set; }


        [Required]
        public int SubmissionId { get; set; }


        /// <summary>
        /// Base64 string representing an image
        /// </summary>
        [Required]
        [MaxLength]
        public string Image { get; set; }


    }
}