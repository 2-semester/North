namespace North.Aids {

    public static class GetString {
        public static string Head(string s, char seperator = '.') {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var i = s.IndexOf(seperator);
            return i < 0 ? s : s.Substring(0, i);
        }

        public static string Tail(string s, char seperator = '.') {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;
            var i = s.IndexOf(seperator);
            return i < 0 ? s : s.Substring(i + 1);
        }
        public static string GetHead(this string s, char seperator = '.')
            => Safe.Run(
                () => {

                    if (string.IsNullOrWhiteSpace(s)) return string.Empty;
                    var i = s.IndexOf(seperator);

                    return i < 0 ? s : s.Substring(0, i);
                }, string.Empty);

        public static string GetTail(this string s, char seperator = '.')
            => Safe.Run(
                () => {
                    if (string.IsNullOrWhiteSpace(s)) return string.Empty;
                    var i = s.IndexOf(seperator);

                    return i < 0 ? s : s.Substring(i + 1);
                }, string.Empty);
    }

}
