using North.Data.Common;

namespace North.Data.SportmanEvent
{
    public abstract class SportmanEventData :UniqueEntityData
    {
        public string SportmanId { get; set; }
        public string EventId { get; set; }
         
    }
}
