using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Models.Commons;
using TourismReserve.Core.Repositories;
using TourismRserve.DAL.Context;

namespace TourismRserve.DAL.Repositories
{
    public class CheckOutRepository(TourismDbContext _context):ICheckOutRepository
    {
     
        public async Task AddAsync(CheckOut checkout)
        {
            await _context.CheckOuts.AddAsync(checkout);
        }

        public async Task SaveChangesAsync()
        {
            try
            {

                var entries = _context.ChangeTracker.Entries().ToList();
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save changes: {ex.Message}");
            }
        }
        public async Task<IEnumerable<CheckOut>> GetAllAsync()
        {
            return await _context.CheckOuts.ToListAsync();
        }



        public async Task DeleteAsync(int id)
        {
            var checkout = await _context.CheckOuts.FindAsync(id);
            if (checkout != null)
            {
                _context.CheckOuts.Remove(checkout);

            }
        }
        public async Task<CheckOut> GetByIdAsync(int id)
        {
            var checkout = await _context.CheckOuts
                .AsTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (checkout == null)
            {
                throw new Exception($"Checkout with ID {id} not found");
            }
            return checkout;
        }

        public void Update(CheckOut checkout)
        {
            _context.Entry(checkout).State = EntityState.Modified;
        }
    }
}

