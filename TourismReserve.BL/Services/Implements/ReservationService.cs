using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.BL.Services.Interfaces;
using TourismReserve.BL.ViewModels.ReservationVM;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;

namespace TourismReserve.BL.Services.Implements
{
    public class ReservationService(IMapper _mapper, IReservationRepository _repo) : IReservationServcie
    {
        public async Task CreateAsync(ReservationCreateVM vm)
        {
            var data = _mapper.Map<Reservation>(vm);
            await _repo.AddAsync(data);
            await _repo.SaveAsync();
        }

        public async Task Delete(int id)
        {
            await _repo.DeleteAsync(id);
            await _repo.SaveAsync();
        }

        public async Task<IEnumerable<ReservationGetVM>> GetAsync()
        {
            var entities = _repo.GetAll();
            var datas = _mapper.Map<IEnumerable<ReservationGetVM>>(entities);
            return datas;
        }

        public async Task UpdateAsync(ReservationUpdateVM vm, int id)
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
