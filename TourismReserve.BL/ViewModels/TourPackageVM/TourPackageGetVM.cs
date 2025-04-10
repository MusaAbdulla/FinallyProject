using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.ViewModels.TourPackageVM
{
    public class TourPackageGetVM
    {
        public int Id { get; set; }
        public string CoverImage { get; set; }
        public string OtherImages { get; set; }
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

    
    }
}
