using System;
using North.Data.Common;

namespace North.Data.Event
{
    public sealed class EventData: DefinedEntityData
    {
        public DateTime EventDate { get; set; }
        public string SportCategoryId { get; set; }
        public string TypeId { get; set; }
        public string OrganizationId { get; set; }
        public string EventListId { get; set; }
        public string LocationId { get; set; }
    }
}
