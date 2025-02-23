using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.BL.ViewModels.ReservationVM
{
    public class ReservationUpdateVM
    {
        [Required, MaxLength(64)]
        public string FullName { get; set; }
        [Required, MaxLength(128), DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }
        public int Children { get; set; }
        public int Youth { get; set; }
        public int Adult { get; set; }
        public bool Extra { get; set; }
    }
}
