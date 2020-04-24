using System.ComponentModel.DataAnnotations;

namespace North.Data.Common
{
    public abstract class NamedEntityData :UniqueEntityData 
    {
        [Required]
        public string Name { get; set; }
        //public string Code { get; set; }
    }
}
