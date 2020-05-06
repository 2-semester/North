using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace North.Facade.Common
{
    public abstract class NamedView :UniqueEntityView
    {
        [Required]
        [DisplayName("Nimi")]
        public string Name { get; set; }
       // public string Code { get; set; }
    }
}
