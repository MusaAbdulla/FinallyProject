using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.CountryVM;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;

namespace TourismReserve.BL.Services.Implements
{
    public class CountryService(ICountryRepository _repo,IMapper _mapper) : ICountryService
    {
        public async Task CreateAsync(CountryCreateVM vm)
        {
           var data = _mapper.Map<Country>(vm);
           await _repo.AddAsync(data);
           await _repo.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<CountryGetVM>> GetAsync()
        {
            var entities =  _repo.GetAll();
            var  datas= _mapper.Map<IEnumerable<CountryGetVM>>(entities);
            return datas;
        }

        public Task UpdateAsync(CountryUpdateVM vm)
        {
            throw new NotImplementedException();
        }
    }
}
