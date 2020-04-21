using North.Data.Common;

namespace North.Data.Sportman
{
    public abstract class SportmanData: NamedEntityData
    {
        //id, nimi, sünnikuupäev
        public string DateOfBirth { get; set; }
    }
}
