namespace booking_app.Entities
{
    internal sealed class Room
    {
        public Room(string roomType, long roomId)
        {
            RoomType = roomType;
            RoomId = roomId;
        }

        public string RoomType { get; private set; }
        public long RoomId { get; private set; }
    }
}
