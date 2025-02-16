using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.BL.ViewModels.UserImageVM;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;

namespace TourismReserve.BL.Services.Implements
{
    public class UserImageService(IUserImageRepository _repo,IMapper _mapper) : IUserImageService
    {
        public async Task CreateAsync(UserImageCreateVM vm)
        {
            var data = _mapper.Map<UserImage>(vm);
            data.ImageUrl = "deafult.jpg";
            await _repo.AddAsync(data);
            await _repo.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }

        public async  Task<IEnumerable<UserImageGetVM>> GetAsync()
        {
            var entities = _repo.GetAll();
            var datas = _mapper.Map<IEnumerable<UserImageGetVM>>(entities);
            return datas;
        }

        public async  Task UpdateAsync(UserImageUpdateVM vm, int id)
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
