using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Enums;

namespace TourismReserve.BL.ViewModels.Check
{
    public class UpdateStatusVM
    {
        public DeliveryStatus Status { get; set; }

        public int Id { get; set; }
    }
}
