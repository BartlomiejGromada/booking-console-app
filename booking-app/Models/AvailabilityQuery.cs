namespace booking_app.Models;

internal sealed record AvailabilityQuery(
    string HotelId,
    DateOnly ArrivalDate,
    DateOnly? DepartureDate,
    string RoomType);