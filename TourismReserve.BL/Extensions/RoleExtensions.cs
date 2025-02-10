using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismReserve.Core.Enums;

namespace TourismReserve.BL.Extensions
{
    public static  class RoleExtensions
    {
        public static string GetRole(this Roles role)
        {
            return role switch
            {
                Roles.Admin=> nameof(Roles.Admin),
                Roles.User=> nameof(Roles.User),
                Roles.Moderator=> nameof(Roles.Moderator),
            };
    }
    }
}
