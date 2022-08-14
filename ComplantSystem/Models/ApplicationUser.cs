using ComplantSystem.Const;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            //set the default value
            IsBlocked = false;
        }
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ApplicationRole Role { get; set; }
        public int? GovernorateId { get; set; }
        public virtual Governorate Governorates { get; set; }
        public int? DirectorateId { get; set; }
        public virtual Directorate Directorates { get; set; }
        public int? SubDirectorateId { get; set; }
        public virtual SubDirectorate SubDirectorate { get; set; }
        public int? VillageId { get; set; }
        public virtual Village Village { get; set; }
        public virtual ICollection<Compalint> CompalintHasSolo { get; set; }

        public int? SocietyId { get; set; }
        public virtual Society Societies { get; set; }
        //public IEnumerable<string> Roles { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsBlocked { get; set; }
        [DataType(DataType.Password)]
        public string UserId { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }



    }


//    public class Beneficiarie
//    {
//        public Beneficiarie()
//        {
//            UploadsComplainte = new List<Compalint>();
//            SubmitionProposals = new List<Proposal>();
//            BenefCommunications = new List<BenefCommunication>();
//            Id = Guid.NewGuid().ToString();

//        }
//        public string Id { get; set; }
//        [Required(ErrorMessage = "يجب ان تقوم بتعبئة هذه الحقل")]
//        [MaxLength(12, ErrorMessage = "Maximum 12 characters only.")]
//        public string IdentityNumber { get; set; }
//        public int UserId { get; set; }
//        public virtual ApplicationUser Admin { get; set; }

//        [Column(TypeName = "nvarchar(50)")]
//        //[Required(ErrorMessage = "يجب ان تقوم بتعبئة هذه الحقل")]
//        //[MaxLength(50,ErrorMessage ="Maximum 12 characters only.")]
//        public string FirstName { get; set; }
//        public string LastName { get; set; }
//        public int? GovernorateId { get; set; }
//        public virtual Governorate Governorate { get; set; }
//        public int? DirectorateId { get; set; }
//        public virtual Directorate Directorate { get; set; }
//        public int? SubDirectorateId { get; set; }
//        public virtual SubDirectorate SubDirectorate { get; set; }
//        public int? VillageId { get; set; }
//        public virtual Village Village { get; set; }
//        [Required]
//        public string PhoneNumber { get; set; }
//        public bool IsActive { get; set; }
//        [Comment("تحديد وقت ادخال الصف في قاعدية البيانات")]
//        //[Timestamp]
//        //[Precision(3)]
//        public DateTime DateCreated { get; set; }
//        public DateTime Update_at { get; set; }
//        public virtual ICollection<Compalint> UploadsComplainte { get; set; }
//        public int? TypeBeneficiariId { get; set; }
//        public virtual TypeBeneficiari TypeBeneficiaris { get; set; }
//        public virtual ICollection<BenefCommunication> BenefCommunications { get; set; }
//        //Relationships
//        public ICollection<Proposal> SubmitionProposals { get; set; }


//    }


}



