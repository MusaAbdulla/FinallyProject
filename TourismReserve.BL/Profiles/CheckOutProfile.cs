using AutoMapper;
using TourismReserve.BL.ViewModels.Check;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.Profiles
{
    public class CheckOutProfile:Profile
    {
        public CheckOutProfile()
        {
            CreateMap<CheckOut, CheckOutVM>()

                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt)).ReverseMap();



        }
    }
}
