using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.ViewModels.SlideVM;
using TourismReserve.BL.ViewModels.UserImageVM;

namespace TourismReserve.BL.Services.Interfaces
{
    public interface IUserImageService
    {
        Task<IEnumerable<UserImageGetVM>> GetAsync();
        Task CreateAsync(UserImageCreateVM vm);
        Task UpdateAsync(UserImageUpdateVM vm, int id);
        Task Delete(int id);
    }
}
