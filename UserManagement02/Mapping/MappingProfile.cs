using AutoMapper;
using UserManagement02.Models;
using UserManagement02.ViewModels;

namespace UserManagement02.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ——— Supervisor ↔ SupervisorViewModel —————————————————————————
            CreateMap<Supervisor, SupervisorViewModel>()
                // map PK
                .ForMember(vm => vm.Id,
                           opt => opt.MapFrom(src => src.SupervisorID))
                // map FK → SelectedDepartmentId
                .ForMember(vm => vm.SelectedDepartmentId,
                           opt => opt.MapFrom(src => src.DepartmentId))
                // ignore dropdown list property in mapping
                .ForMember(vm => vm.Departments,
                           opt => opt.Ignore())
                .ReverseMap()
                // map back PK
                .ForMember(ent => ent.SupervisorID,
                           opt => opt.MapFrom(vm => vm.Id))
                // map SelectedDepartmentId → DepartmentId
                .ForMember(ent => ent.DepartmentId,
                           opt => opt.MapFrom(vm => vm.SelectedDepartmentId))
                // do not map navigation property
                .ForMember(ent => ent.Department,
                           opt => opt.Ignore());

            // ——— AppUser ↔ UserViewModel ————————————————————————————————
            CreateMap<AppUser, UserViewModel>()
                // do not map hashed password back
                .ForMember(vm => vm.Password,
                           opt => opt.Ignore())
                .ReverseMap()
                // do not overwrite DB‐generated UserID
                .ForMember(ent => ent.UserID,
                           opt => opt.Ignore());

            // ——— Trainee ↔ TraineeViewModel ———————————————————————————
            CreateMap<Trainee, TraineeViewModel>()
                .ForMember(vm => vm.TraineeId,
                           opt => opt.MapFrom(src => src.TraineeId))
                .ForMember(vm => vm.SelectedDepartmentId,
                           opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(vm => vm.SelectedSupervisorId,
                           opt => opt.MapFrom(src => src.SupervisorId))
                // ignore dropdown properties
                .ForMember(vm => vm.Departments,
                           opt => opt.Ignore())
                .ForMember(vm => vm.Supervisor,
                           opt => opt.Ignore());

            CreateMap<TraineeViewModel, Trainee>()
                .ForMember(ent => ent.TraineeId,
                           opt => opt.MapFrom(vm => vm.TraineeId))
                .ForMember(ent => ent.DepartmentId,
                           opt => opt.MapFrom(vm => vm.SelectedDepartmentId))
                .ForMember(ent => ent.SupervisorId,
                           opt => opt.MapFrom(vm => vm.SelectedSupervisorId));
        }
    }
}
