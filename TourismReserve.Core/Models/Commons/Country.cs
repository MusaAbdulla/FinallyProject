using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.Core.Models.Commons
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<TourPackage> TourPackages { get; set; }
    }
}
