using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.CountryVM;

namespace TourismReserve.BL.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryGetVM>> GetAsync();
        Task CreateAsync(CountryCreateVM vm);
        Task UpdateAsync(CountryUpdateVM vm,int id);
        Task Delete(int id);    
    }
}
