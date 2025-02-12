using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.BL.ViewModels.TourPackageVM;

namespace TourismReserve.BL.Services.Interfaces
{
    public interface ITourPackageService
    {
        Task<IEnumerable<TourPackageGetVM>> GetAsync();
        Task CreateAsync(TourPackageCreateVM vm);
        Task UpdateAsync(TourPackageUpdateVM vm, int id);
        Task Delete(int id);
    }
}
