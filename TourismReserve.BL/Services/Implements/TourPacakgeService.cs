using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.BL.ViewModels.TourPackageVM;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;

namespace TourismReserve.BL.Services.Implements
{
    public class TourPacakgeService(ITourPackageRepository _repo,IMapper _mapper) : ITourPackageService
    {
        public async Task CreateAsync(TourPackageCreateVM vm)
        {
            var data = _mapper.Map<TourPackage>(vm);
            data.CoverImage = "deafult.jpg";
            data.OtherImages = "deafult.jpg";
            await _repo.AddAsync(data);
            await _repo.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }

        public async  Task<IEnumerable<TourPackageGetVM>> GetAsync()
        {
            var entities = _repo.GetAll();
            var datas = _mapper.Map<IEnumerable<TourPackageGetVM>>(entities);
            return datas;
        }

        public async Task UpdateAsync(TourPackageUpdateVM vm, int id)
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
