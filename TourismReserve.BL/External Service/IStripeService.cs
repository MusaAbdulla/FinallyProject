using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.BL.External_Service
{
    public interface IStripeService
    {
        Task<string> CreateCheckoutSession(decimal amount, string currency);
    }
}
