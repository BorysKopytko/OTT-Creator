namespace OTTCreator.Client.Models;

public class ContentItem
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Type { get; set; }
    public Uri Image { get; set; }
    public Uri CroppedImage { get; set; }
    public Uri Stream { get; set; }
    public bool HasVideo { get; set; }
}
