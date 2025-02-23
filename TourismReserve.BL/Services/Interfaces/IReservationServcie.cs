using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.CountryVM;
using TourismReserve.BL.ViewModels.ReservationVM;

namespace TourismReserve.BL.Services.Interfaces
{
    public interface IReservationServcie
    {
        Task<IEnumerable<ReservationGetVM>> GetAsync();
        Task CreateAsync(ReservationCreateVM vm);
        Task UpdateAsync(ReservationUpdateVM vm, int id);
        Task Delete(int id);
    }
}
