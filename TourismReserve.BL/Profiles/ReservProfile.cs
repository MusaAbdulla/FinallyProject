using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.ReservationVM;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.Profiles
{
    public class ReservProfile:Profile 
    {
        public ReservProfile()
        {
            CreateMap<ReservationCreateVM, Reservation>();
            CreateMap<ReservationUpdateVM, Reservation>();
        }
    }
}
