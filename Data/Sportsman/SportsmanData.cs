using System;
using North.Data.Common;

namespace North.Data.Sportsman
{
    public abstract class SportsmanData: NamedEntityData
    {
        public DateTime DateOfBirth { get; set; }
    }
}
