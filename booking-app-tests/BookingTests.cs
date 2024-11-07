using booking_app.Entities;

namespace booking_app_tests;

public class BookingTests
{
    public static IEnumerable<object[]> DateForOverlapingReturnTrue =>
        [
            [DateOnly.Parse("2024-09-02")],
            [DateOnly.Parse("2024-09-01"), DateOnly.Parse("2024-09-06")],
            [DateOnly.Parse("2024-08-31"), DateOnly.Parse("2024-09-03")],
        ];

    public static IEnumerable<object[]> DateForOverlapingReturnFalse =>
    [
            [DateOnly.Parse("2024-08-31")],
            [DateOnly.Parse("2024-09-04")],
            [DateOnly.Parse("2024-09-03"), DateOnly.Parse("2024-09-05")]
    ];

    [Theory]
    [MemberData(nameof(DateForOverlapingReturnTrue))]
    public void Booking_Is_Overlapping_Should_Return_True(
        DateOnly arrivalDate,
        DateOnly? departureDate = null)
    {
        var booking = new Booking(
            "H1",
            new DateOnly(2024, 09, 01),
            new DateOnly(2024, 09, 03),
            "DBL",
            "Prepaid");

        var result = booking.IsOverlapping(arrivalDate, departureDate);
        Assert.True(result);
    }

    [Theory]
    [MemberData(nameof(DateForOverlapingReturnFalse))]
    public void Booking_Is_Overlapping_Should_Return_False(
      DateOnly arrivalDate,
      DateOnly? departureDate = null)
    {
        var booking = new Booking(
            "H1",
            new DateOnly(2024, 09, 01),
            new DateOnly(2024, 09, 03),
            "DBL",
            "Prepaid");

        var result = booking.IsOverlapping(arrivalDate, departureDate);
        Assert.False(result);
    }
}