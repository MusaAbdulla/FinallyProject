using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.Extensions;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.BL.ViewModels.TourPackageVM;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;

namespace TourismReserve.BL.Services.Implements
{
    public class TourPacakgeService(ITourPackageRepository _repo,IMapper _mapper,IHostingEnvironment _env) : ITourPackageService
    {
        public async Task CreateAsync(TourPackageCreateVM vm)
        {
            var data = _mapper.Map<TourPackage>(vm);
            TourPackage tourPackage = vm;
            if (vm.OtherImages != null)
            {
                tourPackage.Images = vm.OtherImages.Select(x => new TourPackageImage
                {
                    ImageUrl = x.UploadAsync(_env.WebRootPath, "imgs", "TR").Result
                }).ToList();
            }


            if (vm.CoverImage != null)
            {
                tourPackage.CoverImage = await vm.CoverImage.UploadAsync(_env.WebRootPath, "imgs", "TR");
            }
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
            foreach (var data in datas)
            {
                if (!string.IsNullOrEmpty(data.CoverImage))
                {
                    data.CoverImage = "/imgs/TR/" + data.CoverImage;  // wwwroot qovluğundan uyğun şəkil yolunu əlavə edin
                }

                if (!string.IsNullOrEmpty(data.OtherImages))
                {
                    data.OtherImages = "/imgs/TR/" + data.OtherImages;  // wwwroot qovluğundan uyğun şəkil yolunu əlavə edin
                }
            }

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
