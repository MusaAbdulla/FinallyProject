﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.Core.Models.Commons
{
    public class Slide:BaseEntity
    {
        public string? Link { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
