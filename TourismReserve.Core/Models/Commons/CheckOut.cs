using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Enums;

namespace TourismReserve.Core.Models.Commons
{
    public class CheckOut:AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public decimal TotalPrice { get; set; }
        public DeliveryStatus Status { get; set; } = DeliveryStatus.Pending;
    }
}
