using AutoMapper;
using bca.api.Data.Entities;
using bca.api.DTOs;

namespace bca.api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to DTO
            CreateMap<Bank, BankDetails>();

            //CreateMap<State, StateDetails>();
            //CreateMap<District, DistrictDetails>()
            //    .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State!.Name));

            //CreateMap<Location, LocationDTO>()
            //    .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank!.Name))
            //    .ForMember(dest => dest.BankShortName, opt => opt.MapFrom(src => src.Bank!.ShortName))
            //    .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.District!.StateId))
            //    .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District!.Name))
            //    .ForMember(dest => dest.Supervisor1Name, opt => opt.MapFrom(src => src.Supervisor1 != null ? src.Supervisor1.FirstName + " " + src.Supervisor1.LastName : string.Empty))
            //    .ForMember(dest => dest.Supervisor1Designation, opt => opt.MapFrom(src => src.Supervisor1 != null ? src.Supervisor1!.Role!.Name : string.Empty))

                //.ForMember(dest => dest.Supervisor2Name, opt => opt.MapFrom(src => src.Supervisor2 != null ? src.Supervisor2.FirstName + " " + src.Supervisor2.LastName : string.Empty))
                //.ForMember(dest => dest.Supervisor2Designation, opt => opt.MapFrom(src => src.Supervisor2 != null ? src.Supervisor2!.Role!.Name : string.Empty))

                //.ForMember(dest => dest.Supervisor3Name, opt => opt.MapFrom(src => src.Supervisor3 != null ? src.Supervisor3.FirstName + " " + src.Supervisor3.LastName : string.Empty))
                //.ForMember(dest => dest.Supervisor3Designation, opt => opt.MapFrom(src => src.Supervisor3 != null ? src.Supervisor3!.Role!.Name : string.Empty));

            CreateMap<ApplicationUser, UserDTO>()
                .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank != null ? src.Bank.Name : string.Empty));

            //CreateMap<TransactionFileUploadLog, TransactionFileUploadLogDTO>()
            //    .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank != null ? src.Bank.Name : string.Empty))
            //    .ForMember(dest => dest.BankTransactionUploadFileTypeName, opt => opt.MapFrom(src => src.BankTransactionUploadFileType != null ? src.BankTransactionUploadFileType.TypeName : string.Empty));

            //CreateMap<Employee, EmployeeDTO>()
            //    .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.Name))
            //    .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role!.Name))
            //    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department!.Name))
            //    .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team!.Name))
            //    .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager != null ? src.Manager.FirstName + " " + src.Manager.LastName : string.Empty));

            //CreateMap<BCAUser, BCAUserDTO>()
            //    .ForMember(dest => dest.PinpadDeviceMakeName, opt => opt.MapFrom(src => src.PinpadDeviceMake!.Name))
            //    .ForMember(dest => dest.BiometricMakeName, opt => opt.MapFrom(src => src.BiometricMake!.Name))
            //    .ForMember(dest => dest.BiometricTypeName, opt => opt.MapFrom(src => src.BiometricType!.Name))
            //    .ForMember(dest => dest.OnboardingStatusDescription, opt => opt.MapFrom(src => EnumHelper.GetDescription(src.OnboardingStatus)));

            CreateMap<UserDocument, UserDocumentDTO>();
            CreateMap<EmployeeDocument, EmployeeDocumentDTO>();

            // DTO to Entity
            CreateMap<BankInput, Bank>();
            //CreateMap<StateInput, State>();
            //CreateMap<DistrictInput, District>();
            //CreateMap<UpdateLocationDTO, Location>();
            //CreateMap<CreateLocationDTO, Location>();

            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateEmployeeDTO, Employee>();

           // CreateMap<CreateBCAUserDTO, BCAUser>();

            CreateMap<Permission, PermissionDTO>();
            CreateMap<Role, RoleDTO>();

            //CreateMap<TeamDTO, Team>().ReverseMap();
            //CreateMap<DepartmentDTO, Department>().ReverseMap();

            //CreateMap<Product, ProductDTO>();
            //CreateMap<CreateProductDTO, Product>();

            //CreateMap<CommissionSeason, SeasonalRateDTO>().ReverseMap();
            //CreateMap<CommissionStage, StagedRateDTO>().ReverseMap();
            //CreateMap<CommissionTier, TieredRateDTO>().ReverseMap();

            //CreateMap<CreateBankProductCommissionRuleDTO, BankProductCommissionRule>();            

            //CreateMap<BankProductCommissionRule, BankProductCommissionRuleDTO>()
            //    .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name));

            //CreateMap<CreateBankTransactionUploadFileTypeDTO, BankTransactionUploadFileType>();

            //CreateMap<MTDTransaction, MTDTransactionDTO>()
            //    .ForMember(dest => dest.KOCode, opt => opt.MapFrom(src => src.BCAUser.KOCode))
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.BCAUser.FirstName ?? ""} {src.BCAUser.LastName ?? ""}".Trim() ));
        }
    }
}
