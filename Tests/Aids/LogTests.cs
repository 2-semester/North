using System;

namespace North.Tests.Aids {

    public static class LogTests {
        internal static ILogBookTests logBook;

        public static void Message(string message) {
            logBook?.WriteEntry(message);
        }

        public static void Exception(Exception e) {
            logBook?.WriteEntry(e);
        }
    }

}



