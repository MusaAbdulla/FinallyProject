using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.Extensions;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.CountryVM;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;

namespace TourismReserve.BL.Services.Implements
{
    public class SlideServices(ISlideRepository _repo ,IMapper _mapper) : ISlideServices
    {
        public async Task CreateAsync(SlideCreateVM vm)
        {
            var data = _mapper.Map<Slide>(vm);
            data.ImageUrl = "deafult.jpg";
            await _repo.AddAsync(data);
            await _repo.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }

        public async  Task<IEnumerable<SlideGetVM>> GetAsync()
        {
            var entities = _repo.GetAll();
            var datas = _mapper.Map<IEnumerable<SlideGetVM>>(entities);
            return datas;
        }

        public async Task UpdateAsync(SlideUpdateVM vm, int id)
        { 
            var data = await _repo.GetByIdAsync(id);
            if (data != null)
            {
                _mapper.Map(vm, data);
                _repo.Update(data);
                await _repo.SaveAsync();
            }
        }
    }

}
