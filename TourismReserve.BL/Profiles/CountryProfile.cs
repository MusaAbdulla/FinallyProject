using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.CountryVM;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.Profiles
{
    public class CountryProfile:Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryCreateVM, Country>();
            CreateMap<CountryUpdateVM, Country>();
            CreateMap<Country, CountryGetVM>();
        }
    }
}
