using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.BL.ViewModels.TourPackageVM
{
    public class TourPackageCreateVM
    {
        public IFormFile CoverImage { get; set; }
        public ICollection<IFormFile> OtherImages { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Day { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ReturnTime { get; set; }
        public int Person { get; set; }
        public int DisCount { get; set; }
        public int CostPrice { get; set; }
        public int SellPrice { get; set; }
        public int CountryId { get; set; }
    }
}
