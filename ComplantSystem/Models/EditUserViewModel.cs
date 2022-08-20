using System;
using System.ComponentModel.DataAnnotations;

namespace ComplantSystem
{
    public class EditUserViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage = "ادخل رقم البطاقة"), MaxLength(12, ErrorMessage = "يجب ان لا يكون رقم البطاقة اكبر من تسعة 12 رقم "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        public string IdentityNumber { get; set; }
        [Required(ErrorMessage = "ادخل رقم الهاتف"), MaxLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اكثر من تسعة ارقام "), MinLength(9, ErrorMessage = "يجب ان لا يكون رقم الهاتف اقل من تسعة ارقام")]
        public string PhoneNumber { get; set; }
        //public virtual ApplicationRole Role { get; set; }
        public byte[] ProfilePicture { get; set; }
        public bool IsBlocked { get; set; }
        public int userRoles { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
