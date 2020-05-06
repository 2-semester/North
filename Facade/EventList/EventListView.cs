using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using North.Facade.Common;

namespace North.Facade.EventList
{
    public sealed class EventListView : NamedView
    {
        public string EventId { get; set; }
    }
}
