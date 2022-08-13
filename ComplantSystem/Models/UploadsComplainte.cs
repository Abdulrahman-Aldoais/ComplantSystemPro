using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplantSystem.Models
{
    public class UploadsComplainte : IEntityBase
    {
        public UploadsComplainte()
        {
            Id = Guid.NewGuid().ToString();
            UploadDate = DateTime.Now;
            //CompalintsHasSolutions = new List<Compalints_Solution>();
          
        }
        public string Id { set; get; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]

        public string TitleComplaint { get; set; }

        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string TypeComplaintId { get; set; }
        public virtual TypeComplaint TypeComplaint { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string DescComplaint { get; set; }
        public int? SocietyId { get; set; }
        public virtual Society Society { get; set; }
        public int StatusCompalintId { get; set; } = 1;
        public virtual StatusCompalint StatusCompalint { get; set; }
        public int StagesComplaintId { get; set; } = 1;
        public StagesComplaint StagesComplaint { get; set; }
        public string PropBeneficiarie { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بإختبار المنطقة المحددة ")]
        public int? GovernorateId { get; set; }
        public virtual Governorate Governorates { get; set; }
        public int? DirectorateId { get; set; }
        public virtual Directorate Directorates { get; set; }
        public int? SubDirectorateId { get; set; }
        public virtual SubDirectorate SubDirectorates { get; set; }
        public int? VillageId { get; set; }
        public virtual Village Villages { get; set; }
        public  List<Compalints_Solution> CompalintsHasSolutions { get; set; }
        public string SolutionsCompalints { get; set; }
        public virtual ApplicationUser HoUser { get; set; }
        [Display(Name = "Original File Name")]
        public string OriginalFileName { get; set; }
        [Display(Name = "File Name")]
        public string FileName { get; set; }
        public decimal Size { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Content Type")]
        public string ContentType { get; set; }

        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; }
      
        [Display(Name = "Download Count")]
     
        public ApplicationUser User { get; set; }

      
    }
}
