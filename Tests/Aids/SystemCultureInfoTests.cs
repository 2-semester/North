


using System.Globalization;

namespace North.Tests.Aids {

    public static class SystemCultureInfoTests {
        public static CultureInfo[] GetSpecificCultures() {
            return GetCultures(CultureTypes.SpecificCultures);
        }

        public static CultureInfo[] GetCultures(CultureTypes types) {
            return SafeTests.Run(() => CultureInfo.GetCultures(types),
                new CultureInfo[0]);
        }

        public static RegionInfo ToRegionInfo(CultureInfo info) {
            return info is null
                ? null
                : SafeTests.Run(() => new RegionInfo(info.LCID), null);
        }
    }

}







