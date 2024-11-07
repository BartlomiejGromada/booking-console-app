using booking_app.Entities;
using booking_app.Helpers;

namespace booking_app.Infrastructure;

internal static class DataContext
{
    private const string BookingsFilePath = @"Files/bookings.json";
    private const string HotelsFilePath = @"Files/hotels.json";

    public static List<Booking> Bookings() => 
        JsonHelpers.ReadFromFiles<List<Booking>>(BookingsFilePath);
    
    public static List<Hotel> Hotels() =>
        JsonHelpers.ReadFromFiles<List<Hotel>>(HotelsFilePath);
}
