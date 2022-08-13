using AutoMapper;
using ComplantSystem.Areas.UsersService.ViewModel;
using ComplantSystem.Models;

namespace ComplantSystem
{
    public class UploadProfile : Profile
    {
        public UploadProfile()
        {
            //CreateMap<InputCompmallintVM, UploadsComplainte>()
            //    .ForMember(u => u.Id, op => op.Ignore())
            //    .ForMember(u => u.UploadDate, op => op.Ignore());
            //CreateMap<UploadsComplainte, InputCompmallintVM>();

            CreateMap<InputCompmallintVM, UploadsComplainte>()
           .ForMember(u => u.Id, op => op.Ignore())
           .ForMember(u => u.UploadDate, op => op.Ignore());

            //CreateMap<InputCompmallintVM, UploadsComplainte>();
        }
    }

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //CreateMap<ApplicationUser,AdminViewModel >()
            //    .ForMember(u=>u.Password , op=>op.MapFrom(u=>u.PasswordHash !=null));

            CreateMap<ApplicationUser, AdminUserViewModel>()
                .ForMember(u => u.Password, op => op.MapFrom(u => u.PasswordHash != null));
          
        }
    }
}
