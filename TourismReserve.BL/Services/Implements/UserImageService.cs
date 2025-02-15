using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.SlideVM;

namespace TourismReserve.BL.Services.Implements
{
    public class UserImageService : IUserImageService
    {
        public Task CreateAsync(SlideCreateVM vm)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SlideGetVM>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(SlideUpdateVM vm, int id)
        {
            throw new NotImplementedException();
        }
    }
}
