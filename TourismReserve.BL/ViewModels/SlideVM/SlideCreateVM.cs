﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.BL.ViewModels.SlideVM
{
    public class SlideCreateVM
    {
        public string Name { get; set; }
        public IFormFile Image {  get; set; }
    }
}
