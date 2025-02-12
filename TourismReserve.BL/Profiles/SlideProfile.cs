using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.Profiles
{
    public class SlideProfile:Profile
    {
        public SlideProfile()
        {
            CreateMap<SlideCreateVM, Slide>()
                .ForMember(y => y.ImageUrl, z => z.Ignore());
            CreateMap<Slide, SlideGetVM>();
            CreateMap<SlideUpdateVM, Slide>();
        }
    }
}
