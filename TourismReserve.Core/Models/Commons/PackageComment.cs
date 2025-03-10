using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.Core.Models.Commons
{
    public class PackageComment:BaseEntity
    {
        public string UserName { get; set; }
        [MaxLength(255)]
        public string Comment { get; set; }
        public int? PackageId { get; set; }
        public TourPackage? Package { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
