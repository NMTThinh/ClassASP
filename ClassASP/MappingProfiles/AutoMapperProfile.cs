using AutoMapper;
using ClassASP.Entities;
using ClassASP.Models;

namespace ClassASP.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateClass, Class>()
                .ForMember(dest => dest.ClassID, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedCl, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedCl, opt => opt.Ignore());
            CreateMap<UpdateClass, Class>()
                .ForMember(dest => dest.ClassID, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedCl, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedCl, opt => opt.Ignore())
                .ConvertUsing(new NullValueIgnoringConverter<UpdateClass, Class>());

            CreateMap<CreateStudent, Student>()
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedSt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedSt, opt => opt.Ignore());
            CreateMap<UpdateStudent, Student>()
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedSt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedSt, opt => opt.Ignore())
                .ConvertUsing(new NullValueIgnoringConverter<UpdateStudent, Student>());
        }
    }
}
