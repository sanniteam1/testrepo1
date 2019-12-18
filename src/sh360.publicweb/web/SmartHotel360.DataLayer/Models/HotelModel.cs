using System;
using System.Collections.Generic;

namespace SmartHotel360.DataLayer.Models
{
    public class HotelModel
    {
		public string city { get; set; }
		public int cityId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int numPhotos { get; set; }
        public string picture { get; set; }
        public int price { get; set; }
        public int rating { get; set; }
		public string checkInTime { get; set; }
		public string checkOutTime { get; set; }
		public string defaultPicture { get; set; }
		public string description { get; set; }
		public string latitude { get; set; }
		public string longitude { get; set; }
		public int pricePerNight { get; set; }
		public string street { get; set; }


		public List<string> pictures { get; set; }
		public List<RoomModel> rooms { get; set; }
		public List<ServiceModel> services { get; set; }
        


        public HotelModel()
        {
			pictures = new List<string>();
			rooms = new List<RoomModel>();
			services = new List<ServiceModel>();
        }
    }

	public class RoomModel {
		public string badgeSymbol { get; set; }
		public int discountApplied { get; set; }
		public int localOriginalRoomPrice { get; set; }
		public int localRoomPrice { get; set; }
		public string roomName { get; set; }
		public int roomId { get; set; }
		public int roomPrice { get; set; }

		public RoomModel() {
			
		}
	}

	public class ServiceModel {
		public int id { get; set; }
		public string name { get; set; }
		public string type { get; set; }

		public ServiceModel() {
			
		}
	}

	public class ReviewModel {
		public string user { get; set; }
		public string room { get; set; }
		public int rating { get; set; }
		public DateTime date { get; set; }
		public string message { get; set; }

		public ReviewModel() {
			
		}
	}
}
