using System;
using System.Net;

namespace North.Tests.Aids{
    public static class WebServiceTests {
        public static string Load(string url) {
            var num = 0;
            while (num <= 3) {
                num++;
                using (var client = new WebClient()) {
                    try { return client.DownloadString(url); }
                    catch (Exception e) { LogTests.Exception(e); }
                }
            }
            return string.Empty;
        }
    }
}