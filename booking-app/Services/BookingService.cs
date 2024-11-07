using booking_app.Entities;
using booking_app.Models;

namespace booking_app.Services;

internal sealed class BookingService
{
    private readonly List<Hotel> _hotels;
    private readonly List<Booking> _bookings;

    public BookingService(List<Hotel> hotels, List<Booking> bookings)
    {
        _hotels = hotels;
        _bookings = bookings;
    }

    public int Availability(AvailabilityQuery query)
    {
        var hotelId = query.HotelId;
        var roomType = query.RoomType;
        var departure = query.DepartureDate;
        var arrival = query.ArrivalDate;

        var hotel = _hotels.FirstOrDefault(h => h.Id == hotelId);
        if (hotel == null) return 0;

        var totalRooms = hotel.CountRoomsByRoomType(roomType);

        var overlappingBookings = _bookings
           .Where(b => b.HotelId == hotelId && b.RoomType == roomType)
           .Where(b => b.IsOverlapping(arrival, departure))
           .ToList();

        var availableRooms = totalRooms - overlappingBookings.Count;

        return availableRooms;
    }
}
