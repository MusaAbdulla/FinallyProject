using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.CountryVM;
using TourismReserve.BL.ViewModels.SlideVM;

namespace TourismReserve.BL.Services.Interfaces
{
    public interface ISlideServices
    {
        Task<IEnumerable<SlideGetVM>> GetAsync();
        Task CreateAsync(SlideCreateVM vm);
        Task UpdateAsync(SlideUpdateVM vm, int id);
        Task Delete(int id);
    }
}
