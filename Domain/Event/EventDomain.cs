using North.Data.Event;
using North.Domain.Common;

namespace North.Domain.Event
{
    //ülesanne on vedada andmeid andmebaasi ja kasutajaliidese "kihi" vahel
    public sealed class EventDomain: Entity<EventData>
    {
        public EventDomain(): this(null) { }
        public EventDomain(EventData data) : base(data) { }
    }
}
