using SQLite;

namespace OTTCreator.Client.Models
{
    public class ContentItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public Uri Image { get; set; }
        public Uri Stream { get; set; }
        public bool HasVideo { get; set; }
        public bool IsLive { get; set; }
    }
}
