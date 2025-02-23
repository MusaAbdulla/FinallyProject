using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.BL.ViewModels.ReservationVM
{
    public class ReservationCreateVM
    {
        [Required, MaxLength(64)]
        public string FullName { get; set; }
   
        public string Number { get; set; }
       public int TourPackageId { get; set; }
        public int Children { get; set; }
        public int Youth { get; set; }
        public int Adult { get; set; }     
    }
}
