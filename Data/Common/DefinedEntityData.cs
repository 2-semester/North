using System.ComponentModel.DataAnnotations;

namespace North.Data.Common
{
    public abstract class DefinedEntityData :NamedEntityData
    {
        [Required]
        public string Definition { get; set; }
    }
}
