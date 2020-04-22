using North.Data.Common;

namespace North.Data.Location
{
    public sealed class LocationData:NamedEntityData
    {
        public string EventId { get; set; }
        public string EventListId { get; set; }
        public string County { get; set; }
        public string City { get; set; }

    }
}
