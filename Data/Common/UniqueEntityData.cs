using System.ComponentModel.DataAnnotations;

namespace North.Data.Common
{
    public abstract class UniqueEntityData:PeriodData
    {
        public string Id { get; set; }
    }
}
