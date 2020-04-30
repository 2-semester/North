using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using North.Facade.Common;

namespace North.Facade.SportsmanEvent
{
    public sealed class SportsmanEventView : PeriodView
    {
        [Required]
        [DisplayName("Osaleja")]
        public string SportsmanId { get; set; }
        [Required]
        [DisplayName("Üritus")]
        public string EventId { get; set; }
        public string GetId()
        {
            return $"{SportsmanId}.{EventId}";
        }
    }
}
