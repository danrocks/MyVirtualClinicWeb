using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyVirtualClinicWeb.Models
{
    /// <summary>
    /// See https://msdn.microsoft.com/en-us/data/jj591621 for Entity Framework Attributes.
    /// </summary>
    public class VirtualClinicSubmissionModel
    {
        private ICollection<ImageModel> _ImageModels;

        /// <summary>
        /// Db generated id for the MyVirtualClinic submission
        /// </summary>
        [Key]
        
        public int SubmissionId { get; set; }

        [Required]
        /// <summary>
        /// Identifer generator created by uploader to tie muiltiple pictues of same thing
        /// taken at the same time together.
        /// </summary> 
        /// [Required]
        public Guid Upload { get; set; }

        /// <summary>
        /// Base64 rendition of image
        /// </summary>
        //[Required]
        //public string Img { get; set; }

        [Required]
        public  ICollection<ImageModel> ImageModels { get; set; }


        [Required]
        public int PersonModelId { get; set; }

        [Required]
        public virtual ICollection<PersonModel> PersonModel { get; set; }

        public void AddImageModel(ImageModel imageModel)
        {
            imageModel.SubmissionId = this.SubmissionId;
            ImageModels.Add(imageModel);
        }

        //[Required]
        //public int PersonId { get; set; }

        /// <summary>
        /// Date update received
        /// </summary>
        [Display(Name = "Date and Time Submitted")]
        public DateTime AuditWhen { get; set; }

        /// <summary>
        /// UserId of person who submitted photos.
        /// EF is smart enough to know that this is a registered user.
        /// </summary>
        [Required]
        public String ApplicationUserId { get; set; }

        /// <summary>
        /// Making this virtual allows ef to override with a mechanism supporting lazy loading 
        /// </summary>
        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }
}