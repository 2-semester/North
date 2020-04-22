using North.Data.Event;
using North.Domain.Common;

namespace North.Domain.Event
{
    //ülesanne on vedada andmeid andmebaasi ja kasutajaliidese "kihi" vahel
    public sealed class Event: Entity<EventData>
    {
        public Event(): this(null) { }
        public Event(EventData data) : base(data) { }
    }
}
