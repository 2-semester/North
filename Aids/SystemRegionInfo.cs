using System.Collections.Generic;
using System.Globalization;

namespace North.Aids {

    public static class SystemRegionInfo {

        public static bool IsCountry(RegionInfo r) {
            return Safe.Run(() => SystemString.StartsWithLetter(r.ThreeLetterISORegionName), false);
        }
        private static void removeNotCountries(List<RegionInfo> cultures)
        {
            for(var i = cultures.Count; i > 0; i--)
            {
                var c = cultures[i - 1];
                if (c!= null && c.EnglishName != null) continue;
                cultures.RemoveAt(i - 1);
            }
        }
    }
}


