using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.UserImageVM;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.Profiles
{
    public class UserImageProfile:Profile
    {
        public UserImageProfile()
        {
            CreateMap<UserImageCreateVM, UserImage>();
            CreateMap<UserImageUpdateVM, UserImage>();
            CreateMap<UserImage, UserImageGetVM>();
        }
    }
}
