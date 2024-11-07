using booking_app.Models;

namespace booking_app.Helpers;

internal static class AvailabilityQueryHelpers
{
    public static AvailabilityQuery? Parse(string input)
    {
        var parts = input.Split('-');
        if (parts.Length < 3 || parts.Length > 4)
        {
            Console.WriteLine("!! Invalid input format !!");
            return null;
        }

        var hotelId = parts[0].Trim();
        var roomType = parts[^1].Trim();

        if (!DateOnly.TryParseExact(parts[1].Trim(), "yyyyMMdd", out var arrivalDate))
        {
            Console.WriteLine("!! Invalid arrival date format. Expected format: yyyyMMdd !!");
            return null;
        }

        DateOnly? departureDate = null;
        if (parts.Length == 4)
        {
            if (!DateOnly.TryParseExact(parts[2].Trim(), "yyyyMMdd", out var parsedDepartureDate))
            {
                Console.WriteLine("!! Invalid departure date format. Expected format: yyyyMMdd !!");
                return null;
            }
            departureDate = parsedDepartureDate;
        }

        return new AvailabilityQuery(hotelId, arrivalDate, departureDate, roomType);
    }
}
