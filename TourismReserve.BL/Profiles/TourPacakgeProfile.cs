﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.TourPackageVM;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.Profiles
{
    public class TourPacakgeProfile:Profile
    {
        public TourPacakgeProfile()
        {
            CreateMap<TourPackageCreateVM, TourPackage>();

            CreateMap<TourPackage, TourPackageGetVM>();

            CreateMap<TourPackageUpdateVM, TourPackage>();
                
        }
    }
}
