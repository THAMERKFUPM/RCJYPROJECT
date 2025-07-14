using AutoMapper;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Supervisors ↔ SupervisorsViewModel
            CreateMap<Supervisor, SupervisorsViewModel>()
                // entity uses SupervisorID, VM uses Id
                .ForMember(vm => vm.Id,
                    opt => opt.MapFrom(src => src.SupervisorID))
                .ReverseMap()
                // and back again
                .ForMember(src => src.SupervisorID,
                    opt => opt.MapFrom(vm  => vm.Id));
            
            // AppUser ↔ UserViewModel
            CreateMap<AppUser, UserViewModel>()
                // everything else auto‐mapped because names match
                // except we ignore the hashed Password coming from the store
                .ForMember(vm => vm.Password,
                    opt => opt.Ignore())
                .ReverseMap()
                // don't overwrite the DB‐generated UserID on insert
                .ForMember(ent => ent.UserID,
                    opt => opt.Ignore());
        }
    }
}