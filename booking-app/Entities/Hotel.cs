namespace booking_app.Entities;

internal sealed class Hotel
{
    private readonly List<RoomType> _roomTypes;
    private readonly List<Room> _rooms;

    public Hotel(
        List<RoomType> roomTypes,
        List<Room> rooms,
        string id, 
        string name)
    {
        _roomTypes = roomTypes;
        _rooms = rooms;
        Id = id;
        Name = name;
    }

    public string Id { get; private set; }
    public string Name { get; private set; }
    public IReadOnlyCollection<RoomType> RoomTypes => _roomTypes;
    public IReadOnlyCollection<Room> Rooms => _rooms;

    public int CountRoomsByRoomType(string roomType) => _rooms.Count(r => r.RoomType == roomType);
}
