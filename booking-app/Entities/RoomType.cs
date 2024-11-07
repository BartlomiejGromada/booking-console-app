namespace booking_app.Entities;

internal sealed class RoomType
{
    private readonly List<string> _amenities;
    private readonly List<string> _features;

    public RoomType(
        List<string> amenities, 
        List<string> features, 
        string code, 
        string description)
    {
        _amenities = amenities;
        _features = features;
        Code = code;
        Description = description;
    }

    public string Code { get; private set; }
    public string Description { get; private set; }
    public IReadOnlyCollection<string> Amenities => _amenities;
    public IReadOnlyCollection<string> Features => _features;
}
