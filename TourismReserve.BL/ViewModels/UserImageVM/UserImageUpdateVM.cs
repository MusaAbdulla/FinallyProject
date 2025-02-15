using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.BL.ViewModels.UserImageVM
{
    public class UserImageUpdateVM
    {
        public IFormFile Image { get; set; }
    }
}
