using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace North.Facade.Common
{
    public abstract class DefinedView :NamedView
    {
        [Required]
        [DisplayName("Kirjeldus")]
        public string Definition { get; set; }
    }
}
