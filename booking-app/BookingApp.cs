using booking_app.Helpers;
using booking_app.Services;

namespace booking_app;

internal class BookingApp
{
    private readonly BookingService _bookingService;

    public BookingApp(BookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("***************************************************************");
            Console.WriteLine("************************* BOOKING APP *************************");
            Console.WriteLine("***************************************************************");
            Console.WriteLine();

            Console.Write("Enter data in format: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("hotelId - arrivalDate - roomType");
            Console.ResetColor();

            Console.Write(" or: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("hotelId - arrivalDate - departureDate - roomType");

            Console.ResetColor();
            Console.Write(@"Example inputs: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("H1 - 20240901 - DBL or H1 - 20240901 - 20240903 - DBL");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("!! If you wanna exit enter blank line !!");
            Console.ResetColor();


            Console.Write("Enter input: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) break;


            var query = AvailabilityQueryHelpers.Parse(input);
            if (query == null)
            {
                Console.WriteLine();
                continue;
            }

            var availability = _bookingService.Availability(query);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Availability: {availability}");
            Console.ResetColor();
            Console.WriteLine();
        }

    }
}
