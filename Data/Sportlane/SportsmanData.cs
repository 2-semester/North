using North.Data.Common;

namespace North.Data.Sportlane
{
    public abstract class SportsmanData: NamedEntityData
    {
        //id, nimi, sünnikuupäev
        public string DateOfBirth { get; set; }
    }
}
