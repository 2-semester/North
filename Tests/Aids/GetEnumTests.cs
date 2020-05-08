




using System;

namespace North.Tests.Aids {

    public static class GetEnumTests {
        public static int Count<T>() {
            return Count(typeof(T));
        }

        public static T Value<T>(int i) {
            return SafeTests.Run(() => (T) Value(typeof(T), i), default(T));
        }

        public static int Count(Type type) {
            return SafeTests.Run(() => Enum.GetValues(type).Length, -1);
        }

        public static object Value(Type type, int i) {
            return SafeTests.Run(() => {
                var v = Enum.GetValues(type);
                return v.GetValue(i);
            }, null);
        }
    }
}



