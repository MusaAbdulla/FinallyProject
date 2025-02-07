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
    public class SlideRepository : GenericRepository<Slide>, ISlideRepository
    {
        public SlideRepository(TourismDbContext _context) : base(_context)
        {
        }
    }
}
