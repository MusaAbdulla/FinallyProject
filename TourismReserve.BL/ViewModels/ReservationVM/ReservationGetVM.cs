using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.BL.ViewModels.ReservationVM
{
    public class ReservationGetVM
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Children { get; set; }
        public int Youth { get; set; }
        public int Adult { get; set; }
        public bool Extra { get; set; }
    }
}
