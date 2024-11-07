using Newtonsoft.Json;

namespace booking_app.Helpers;

internal static class JsonHelpers
{
    public static T ReadFromFiles<T>(string filePath)
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(filePath)) ??
                    throw new Exception("An error occurred during deserialization");
    }
}
