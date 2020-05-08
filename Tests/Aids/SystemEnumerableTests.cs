using System;
using System.Collections.Generic;
using System.Linq;

namespace North.Tests.Aids {
    public static class SystemEnumerableTests {

        public static IEnumerable<T> OrderBy<T>(IEnumerable<T> list, Func<T, string> func) {
            return SafeTests.Run(() => list.OrderBy(func),
                new List<T>() as IEnumerable<T>, true);
        }

        public static IEnumerable<T> Distinct<T>(IEnumerable<T> list) {
            return SafeTests.Run(list.Distinct,
                new List<T>(), true);
        }

        public static IEnumerable<TTo> Convert<TFrom, TTo>(IEnumerable<TFrom> list,
            Func<TFrom, TTo> func) {
            return SafeTests.Run(() => list.Select(func),
                new List<TTo>(), true);
        }
    }
}




