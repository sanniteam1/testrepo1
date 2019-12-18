using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHotel360.PublicWeb.Models
{
    public class ReservationModel
    {
        public string Location { get; set; }
        public int LocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }
        public int Babies { get; set; }
        public int Rooms { get; set; }
        public bool WithPet { get; set; }
        public int HotelId { get; set; }
        public int RoomId { get; set; }
        public int TotalGuest
        {
            get
            {
                return Adults + Kids + Babies;
            }
        }
        public string GuestWord
        {
            get
            {
                if (Adults + Kids + Babies > 1)
                {
                    return "Guests";
                }
                else return "Guest";
            }
        }
        public string RoomWord
        {
            get
            {
                if (Rooms > 1)
                {
                    return "Rooms";
                }
                else return "Room";
            }
        }

    }
}
