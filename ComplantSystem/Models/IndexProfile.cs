//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.ComponentModel.DataAnnotations;
//using System.Threading.Tasks;

//namespace ComplantSystem.Models
//{
//    public partial class IndexProfile 
//    {
//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly SignInManager<ApplicationUser> _signInManager;

//        public IndexProfile(
//            UserManager<ApplicationUser> userManager,
//            SignInManager<ApplicationUser> signInManager)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//        }

//        public string Username { get; set; }

//        [TempData]
//        public string StatusMessage { get; set; }
//        [TempData]
//        public string UserNameChangeLimitMessage { get; set; }

//        [BindProperty]
//        public InputModel Input { get; set; }

//        public class InputModel
//        {
//            [Display(Name = "First Name")]
//            public string FirstName { get; set; }
//            [Display(Name = "Last Name")]
//            public string LastName { get; set; }
//            [Display(Name = "Username")]
//            public string Username { get; set; }
//            [Phone]
//            [Display(Name = "Phone number")]
//            public string PhoneNumber { get; set; }
//            [Display(Name = "Profile Picture")]
//            public byte[] ProfilePicture { get; set; }
//        }

       


//    }
//}
