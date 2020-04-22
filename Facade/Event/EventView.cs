using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using North.Facade.Common;

namespace North.Facade.Event
{
    public sealed class EventView : DefinedView
    {
        [DataType(DataType.Date)]
        [DisplayName("Kuupäev")]
        public DateTime EventDate { get; set; }
        [Required]
        [DisplayName("Spordivaldkond")]
//dropdownlist 5 asjaga
        public string SportCategoryId { get; set; }
        [Required]
        [DisplayName("Spordiala")]
        public string TypeId { get; set; }
        [Required]
        [DisplayName("Korraldaja")]
        public string OrganizationId { get; set; }
        //[Required]
        [DisplayName("Ürituste sari")]
        public string EventListId { get; set; }
        //[Required]
        //[DisplayName("Spordiala")]
        //public string SportsmanEventId { get; set; }
    }

}
