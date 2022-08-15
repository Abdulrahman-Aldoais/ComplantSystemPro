using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComplantSystem.Models
{

    public class InputFile
    {
        [Required]
        public IFormFile File { get; set; }

    }


    public class InputCompmallintVM
    {
        public string Id { get; set; }
        public IFormFile File { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string TitleComplaint { get; set; }

        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string TypeComplaintId { get; set; }


        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string DescComplaint { get; set; }

        public int? SocietyId { get; set; }

        public int StatusCompalintId { get; set; } = 1;

        public int StagesComplaintId { get; set; } = 1;

        //[Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string PropBeneficiarie { get; set; }
        //RelationShipes one to many with Compalints and Village

        public List<Governorate> Governorates { get; set; }
        public int GovernorateId { get; set; }

        public int? DirectorateId { get; set; }

        public int? SubDirectorateId { get; set; }

        //[Required(ErrorMessage = "يجب ان تقوم بإختبار المنطقة المحددة ")]
        public int? VillageId { get; set; }
        //[ForeignKey("VillageId")]

        public DateTime CompDate { get; set; }
        //[Timestamp]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime CompDateUp { get; set; }
        public  List<string> UserwhosolvedId { get; set; }
        public string SolutionsCompalints { get; set; }

  
        public string UserId { get; set; }
        public virtual ApplicationUser HoUser { get; set; }
        public DateTime UploadDate { get; set; }



        public string OriginalFileName { get; set; }
        public string FileName { get; set; }
        public decimal Size { get; set; }

        public string ContentType { get; set; }

    }

    public class UploadViewModel
    {
        public string TitleComplaint { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string TypeComplaintId { get; set; }
        [Required(ErrorMessage = "يجب ان تقوم بكتابة هذه الحقل ")]
        public string DescComplaint { get; set; }
        public int? SocietyId { get; set; }
        public int StatusCompalintId { get; set; } 
        public int StagesComplaintId { get; set; } 
        public string PropBeneficiarie { get; set; }
    
        public List<Governorate> Governorates { get; set; }
        public int GovernorateId { get; set; }
        public int? DirectorateId { get; set; }
        public int? SubDirectorateId { get; set; }
        public int? VillageId { get; set; }

       
    }



}

