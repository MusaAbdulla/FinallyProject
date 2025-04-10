using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.Core.Models.Commons
{
    public class TourPackage : BaseEntity
    {
        public string CoverImage { get; set; }
        public string OtherImages { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Day { get; set; }
        public int Person { get; set; }
        public int SellPrice { get; set; }
        public ICollection<TourPackageImage> Images { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<PackageComment> Comments { get; set; }
    }
}
