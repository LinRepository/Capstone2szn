using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstoneszn
{
    public static class Session
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static string Role { get; set; }
        public static string Name { get; set; }
        public static int BuildingId { get; set; }

        public static bool LoggingOut { get; set; }

        public static bool IsLandlord => Role == "Landlord";

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
            Name = null;
            BuildingId = 0;
        }
    }
}
