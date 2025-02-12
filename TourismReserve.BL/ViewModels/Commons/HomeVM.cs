using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.SlideVM;

namespace TourismReserve.BL.ViewModels.Commons
{
    public class HomeVM
    {
        public IEnumerable<SlideGetVM> Sliders { get; set; }
    }
}
