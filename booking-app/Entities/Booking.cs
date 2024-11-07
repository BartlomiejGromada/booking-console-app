using booking_app.Converters;
using Newtonsoft.Json;

namespace booking_app.Entities
{
    internal sealed class Booking
    {
        public Booking(
            string hotelId,
            DateOnly arrival,
            DateOnly departure,
            string roomType,
            string roomRate)
        {
            HotelId = hotelId;
            Arrival = arrival;
            Departure = departure;
            RoomType = roomType;
            RoomRate = roomRate;
        }

        public string HotelId { get; private set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly Arrival { get; private set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly Departure { get; private set; }
        public string RoomType { get; private set; }
        public string RoomRate { get; private set; }

        public bool IsOverlapping(DateOnly startDate, DateOnly? endDate = null)
        {
            DateOnly effectiveEndDate = endDate ?? startDate;

            return startDate < Departure && effectiveEndDate > Arrival;
        }
    }
}
