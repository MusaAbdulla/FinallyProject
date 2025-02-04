using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.Core.Models.Commons
{
    public class Reservation : BaseEntity
    {
        public DateTime Calendar { get; set; }
        public int Time { get; set; }
        public int Children { get; set; }
        public int Youth { get; set; }
        public int Adult { get; set; }
        public bool Extra { get; set; }

    }
}
