using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourismReserve.Core.Models.Commons
{
    public class AppUser
    {
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImagePath { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime? LastLogin { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? AccountCreatedAt { get; set; }
    }
}
