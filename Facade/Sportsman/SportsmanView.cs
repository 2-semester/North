using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using North.Facade.Common;

namespace North.Facade.Sportsman
{
    public sealed class SportsmanView : NamedView
    {
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Sünnikuupäev")]
        public DateTime DateOfBirth { get; set; }
    }
}
