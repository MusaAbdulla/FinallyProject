using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.Check;
using TourismReserve.Core.Models.Commons;

namespace TourismReserve.BL.External_Service
{
    public interface IChechOutService
    {
        Task AddCheckoutAsync(CheckOut checkout);
        Task<IEnumerable<CheckOutVM>> GetAllCheckoutsAsync();
        Task UpdateStatusAsync(int id, UpdateStatusVM updateStatusDto);
        Task DeleteCheckoutAsync(int id);
        Task<CheckOut> GetCheckoutByIdAsync(int id);
        Task<IEnumerable<CheckOut>> GetUserCheckoutsAsync(string userId);
    }
}
