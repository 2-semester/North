using System.Globalization;

namespace North.Aids {
    public class UseCultureTests
    {
        public static CultureInfo Current => CultureInfo.CurrentCulture;
        public static CultureInfo English => new CultureInfo("en-GB");
        public static CultureInfo Invariant => CultureInfo.InvariantCulture;
    }
}