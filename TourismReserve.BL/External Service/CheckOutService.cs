using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using TourismReserve.BL.ViewModels.Check;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;

namespace TourismReserve.BL.External_Service
{
    public class CheckOutService : IChechOutService
    {
        private readonly ICheckOutRepository _checkoutRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public CheckOutService(ICheckOutRepository checkoutRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _checkoutRepository = checkoutRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task AddCheckoutAsync(CheckOut checkout)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

            checkout.CreatedBy = userName ?? "Anonymous";
            checkout.CreatedAt = DateTime.UtcNow;

            await _checkoutRepository.AddAsync(checkout);
            await _checkoutRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CheckOutVM>> GetAllCheckoutsAsync()
        {
            var checkouts = await _checkoutRepository.GetAllAsync();
            var checkoutDtos = _mapper.Map<IEnumerable<CheckOutVM>>(checkouts);
            return checkoutDtos;
        }

        public async Task UpdateStatusAsync(int id, UpdateStatusVM updateStatusDto)
        {
            var checkout = await _checkoutRepository.GetByIdAsync(id);

            if (checkout == null)
            {
                throw new Exception($"Checkout with ID {id} not found");
            }

            try
            {
                var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name;

                checkout.Status = updateStatusDto.Status;
                checkout.UpdatedBy = userName ?? "Anonymous";
                checkout.UpdatedAt = DateTime.UtcNow;

                await _checkoutRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update status: {ex.Message}");
            }
        }
        public async Task DeleteCheckoutAsync(int id)
        {
            await _checkoutRepository.DeleteAsync(id);
            await _checkoutRepository.SaveChangesAsync();
        }
        public async Task<CheckOutVM> GetCheckoutByIdAsync(int id)
        {
            var checkout = await _checkoutRepository.GetByIdAsync(id);
            var checkoutDto = _mapper.Map<CheckOutVM>(checkout);
            return checkoutDto;
        }

        public async Task<IEnumerable<CheckOutVM>> GetUserCheckoutsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var checkouts = await _checkoutRepository.GetAllAsync();
            var userCheckouts = checkouts.Where(c => c.CreatedBy == user.PhoneNumber);

            return _mapper.Map<IEnumerable<CheckOutVM>>(userCheckouts);
        }

        Task<CheckOut> IChechOutService.GetCheckoutByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CheckOut>> IChechOutService.GetUserCheckoutsAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
