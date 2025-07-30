using AutoMapper;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<Supervisor, SupervisorViewModel>()
                .ForMember(dest => dest.SupervisorId,
                           opt => opt.MapFrom(src => src.SupervisorId))
                .ForMember(dest => dest.SupervisorFullName,
                           opt => opt.MapFrom(src => src.SupervisorFullName))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber,
                           opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.SelectedDepartmentId,
                           opt => opt.MapFrom(src => src.DepartmentId ?? 0))
                .ForMember(dest => dest.Department,
                           opt => opt.MapFrom(src => src.Department != null
                                                        ? src.Department.DepartmentName
                                                        : string.Empty));


            CreateMap<SupervisorViewModel, Supervisor>()
                .ForMember(dest => dest.SupervisorId,
                           opt => opt.MapFrom(src => src.SupervisorId))
                .ForMember(dest => dest.SupervisorFullName,
                           opt => opt.MapFrom(src => src.SupervisorFullName))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber,
                           opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.DepartmentId,
                           opt => opt.MapFrom(src => src.SelectedDepartmentId));


            CreateMap<AppUser, UserViewModel>()
            .ForMember(dst => dst.UserID,
                       opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.FullName,
                       opt => opt.MapFrom(src => src.FullName))
            .ForMember(dst => dst.Email,
                       opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.PhoneNumber,
                       opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dst => dst.IsActive,
                       opt => opt.MapFrom(src => src.IsActive));

            CreateMap<UserViewModel, AppUser>();

            CreateMap<Trainee, TraineeViewModel>()
            .ForMember(dst => dst.TraineeId,
                       opt => opt.MapFrom(src => src.TraineeId))
            .ForMember(dst => dst.FullName,
                       opt => opt.MapFrom(src => src.FullName))
            .ForMember(dst => dst.Email,
                       opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.PhoneNumber,
                       opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dst => dst.UniversityName,
                       opt => opt.MapFrom(src => src.UniversityName))
            .ForMember(dst => dst.Major,
                       opt => opt.MapFrom(src => src.Major))
            .ForMember(dst => dst.DepartmentName,
                       opt => opt.MapFrom(src => src.Department != null
                                               ? src.Department.DepartmentName
                                               : string.Empty))
            .ForMember(dst => dst.SupervisorFullName,
                       opt => opt.MapFrom(src => src.Supervisor != null
                                               ? src.Supervisor.SupervisorFullName
                                               : string.Empty))
            .ForMember(dst => dst.SelectedDepartmentId,
                       opt => opt.MapFrom(src => src.DepartmentId ?? 0))
            .ForMember(dst => dst.SelectedSupervisorId,
                       opt => opt.MapFrom(src => src.SupervisorId ?? 0))
            .ForMember(dst => dst.IsActive,
                       opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dst => dst.CreatedAt,
                       opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<TraineeViewModel, Trainee>()
            .ForMember(dst => dst.TraineeId,
                       opt => opt.MapFrom(src => src.TraineeId))
            .ForMember(dst => dst.FullName,
                       opt => opt.MapFrom(src => src.FullName))
            .ForMember(dst => dst.Email,
                       opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.PhoneNumber,
                       opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dst => dst.UniversityName,
                       opt => opt.MapFrom(src => src.UniversityName))
            .ForMember(dst => dst.Major,
                       opt => opt.MapFrom(src => src.Major))
            .ForMember(dst => dst.DepartmentId,
                       opt => opt.MapFrom(src => src.SelectedDepartmentId))
            .ForMember(dst => dst.SupervisorId,
                       opt => opt.MapFrom(src => src.SelectedSupervisorId))
            .ForMember(dst => dst.IsActive,
                       opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dst => dst.CreatedAt,
                       opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Trainee, TraineeRowVM>()
                .ForAllMembers(o => o.Ignore());
            CreateMap<Supervisor, SupervisorViewModel>();
            CreateMap<SupervisorViewModel, Supervisor>();
        }
    }
}

