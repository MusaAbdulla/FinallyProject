using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;

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
   
        public int Person { get; set; }
   
        public int SellPrice { get; set; }
      

        public static implicit operator TourPackage(TourPackageCreateVM vm)
        {
            return new TourPackage
            { 
            
            SellPrice = vm.SellPrice,
            Day = vm.Day,
            Name = vm.Name,
            Description = vm.Description,
            Person = vm.Person,
            Location = vm.Location,
            };

        }
    }
}
