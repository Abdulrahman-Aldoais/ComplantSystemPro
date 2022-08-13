using System.ComponentModel.DataAnnotations;

namespace ComplantSystem.Areas.UsersService.ViewModel
{
    public class LoginViewModel2
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
