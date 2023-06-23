namespace ITUMIK_dotnet_api.Models;


public class EntryWithoutID
{
    public string TOPIC { get; set; } = null!;
    public Dictionary<string, bool> VALUES { get; set; } = null!;
}