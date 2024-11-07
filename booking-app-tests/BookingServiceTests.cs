using booking_app.Entities;
using booking_app.Models;
using booking_app.Services;

namespace booking_app_tests;

public class BookingServiceTests
{
    private readonly List<Hotel> _hotels;
    private readonly AvailabilityQuery _availabilityQuery;

    public BookingServiceTests()
    {
        var roomType = new RoomType(["WiFi", "TV"], ["Non-smoking"], "SGL", "Single Room");
        var rooms = new List<Room>
        {
            new("DBL", 1),
            new("DBL", 2),
            new("DBL", 3),
            new("DBL", 4),
            new("DBL", 5)
        };

        _hotels = [ new([roomType], rooms, "H1", "Hotel California") ];
        _availabilityQuery = new AvailabilityQuery(
            "H1",
            new DateOnly(2024, 11, 10),
            new DateOnly(2024, 11, 12),
            "DBL");
    }

    [Fact]
    public void Availability_ReturnsAvailableRooms_WhenNoOverlappingBookings()
    {
        // Arrange
        var bookings = new List<Booking>();
        var service = new BookingService(_hotels, bookings);

        // Act
        var availableRooms = service.Availability(_availabilityQuery);

        // Assert
        Assert.Equal(5, availableRooms);
    }

    [Fact]
    public void Availability_ReturnsAvailableRooms_WhenSomeBookingsOverlap()
    {
        // Arrange
        var bookings = new List<Booking>
        {
            new("H1", new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12), "DBL", "Prepaid")
        };

        var service = new BookingService(_hotels, bookings);

        // Act
        var availableRooms = service.Availability(_availabilityQuery);

        // Assert
        Assert.Equal(4, availableRooms);
    }

    [Fact]
    public void Availability_ReturnsZero_WhenAllRoomsAreBooked()
    {
        // Arrange
        var bookings = new List<Booking>
        {
            new("H1", new DateOnly(2024, 11, 10), new DateOnly(2024, 11, 12), "DBL", "Prepaid"),
            new("H1", new DateOnly(2024, 11, 11), new DateOnly(2024, 11, 13), "DBL", "Prepaid")
        };
        var service = new BookingService(_hotels, bookings);

        // Act
        var availableRooms = service.Availability(_availabilityQuery);

        // Assert
        Assert.Equal(3, availableRooms);
    }
}