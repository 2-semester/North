using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace North.Tests.Aids {

    public static class SystemRegionInfoTests {

        public static bool IsCountry(RegionInfo r) {
            return SafeTests.Run(() => SystemStringTests.StartsWithLetter(r.ThreeLetterISORegionName), false);
        }

        public static List<RegionInfo> GetRegionsList() {
            return SafeTests.Run(() => {
                var cultures = SystemCultureInfoTests.GetSpecificCultures();
                var regions = SystemEnumerableTests.Convert(cultures, SystemCultureInfoTests.ToRegionInfo);
                regions = SystemEnumerableTests.Distinct(regions);
                var list = regions.ToList();
                removeNotCountries(list);
                regions = SystemEnumerableTests.OrderBy(list.ToArray(), p => p.EnglishName);
                return regions.ToList();
            }, new List<RegionInfo>());
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


