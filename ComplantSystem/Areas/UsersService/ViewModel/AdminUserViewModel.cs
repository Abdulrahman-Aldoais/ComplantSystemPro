using ComplantSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Areas.UsersService.ViewModel
{
    public class AdminUserViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

        public string IdentityNumber { get; set; }
        public string PhoneNumber { get; set; }
        public ApplicationRole Role { get; set; }
        public int? GovernorateId { get; set; }
        public int? DirectorateId { get; set; }
        public int? SubDirectorateId { get; set; }
        public int? VillageId { get; set; }
        public int? SocietyId { get; set; }
        //public IEnumerable<string> Roles { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsBlocked { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "يرجى ادخال كلمة المرور"), RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "صيغة يجب ان تكون كلمة السر ارقام و حروف و رموز")]

        public string Password { get; set; }

        [Required(ErrorMessage = "يرجى اعادة ادخال كلمة المرور"), Compare("Password", ErrorMessage = "كلمة المرور غير متطابقة")]
        public string ConfirmPassword { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
