using booking_app;
using booking_app.Infrastructure;
using booking_app.Services;


var hotels = DataContext.Hotels();
var bookings = DataContext.Bookings();
var bookingService = new BookingService(hotels, bookings);

var app = new BookingApp(bookingService);
app.Run();