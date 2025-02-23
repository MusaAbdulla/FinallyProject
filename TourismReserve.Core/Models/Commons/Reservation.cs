using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.Core.Models.Commons
{
    public class Reservation : BaseEntity
    {
        public TourPackage TourPackage { get; set; }
        public int TourPackageId { get; set; }
        public string FullName  { get; set; }
        public string Number { get; set; } 
        public int Children { get; set; }
        public int Youth { get; set; }
        public int Adult { get; set; }

    }
}
