namespace North.Aids {
    public class IsRunningTests {

        private const string testFramework = "Microsoft.VisualStudio.QualityTools.UnitTestFramework";
        private const string unitTesting = "Microsoft.VisualStudio.TestPlatform";

        public static bool Namespace(string name) {
            if (string.IsNullOrEmpty(name)) return false;
            return
                SafeTests.Run(() => {
                    var assemblies = GetSolutionTests.Assemblies;
                    foreach (var a in assemblies) { if (a.FullName.StartsWith(name)) return true; }
                    return false;
                }, false);
        }
        public static bool Tests(bool ignore = false) {
            return !ignore && (
                       Namespace(testFramework) || Namespace(unitTesting));
        }
    }
}
