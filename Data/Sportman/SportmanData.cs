using System;
using North.Data.Common;

namespace North.Data.Sportman
{
    public abstract class SportmanData: NamedEntityData
    {
        public DateTime DateOfBirth { get; set; }
    }
}
