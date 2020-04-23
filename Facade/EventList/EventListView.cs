using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using North.Facade.Common;

namespace North.Facade.EventList
{
    public sealed class EventListView : NamedView
    {
        [Required]
        [DisplayName("Ürituse nimi")]
        public string EventId { get; set; }
    }
}
