using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.Core.Models.Commons
{
    public class TourPackageImage:BaseEntity
    {
        public TourPackage TourPackage { get; set; }
        public int TourPackageId { get; set; }
        public string ImageUrl  { get; set; }
    }
}
