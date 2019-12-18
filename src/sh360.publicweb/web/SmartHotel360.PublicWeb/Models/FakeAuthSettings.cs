using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel360.PublicWeb.Models
{
    public static class FakeAuthSettings
    {
        public static void LoginFakeAuthSettings()
        {
            Name = "Scott Hansleman";
            PicUrl = "assets/images/pichotels/user_picture.png";
            UserId = "ALFKI";
            IsLoggedIn = true;
        }
        public static void LogoffFakeAuthSettings()
        {
            Name = "";
            PicUrl = "";
            UserId = "";
            IsLoggedIn = false;
        }

        public static string Name { get; set; }
        public static string PicUrl { get; set; }
        public static string UserId { get; set; }
        public static bool IsLoggedIn { get; set; }
    }
}
