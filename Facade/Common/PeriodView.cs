using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace North.Facade.Common
{
    public abstract class PeriodView
    {

        [DataType(DataType.Date)]
        [DisplayName("Alguskuupäev")]
        public DateTime? ValidFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Lõppkuupäev")]
        public DateTime? ValidTo { get; set; }
    }
}
