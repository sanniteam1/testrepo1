using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel360.PublicWeb.Models
{
    public class HomeViewModel
    {
        public ReservationModel reservation { get; set; }
        public string Tweet { get; set; }

        public HomeViewModel()
        {
            reservation = new ReservationModel();
        }

    }
}
