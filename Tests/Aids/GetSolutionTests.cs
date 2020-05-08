using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using North.Aids;

namespace North.Tests.Aids {

    public static class GetSolutionTests {

        public static AppDomain Domain => AppDomain.CurrentDomain;

        public static List<Assembly> Assemblies =>
            SafeTests.Run(() => Domain.GetAssemblies().ToList(),
                new List<Assembly>());

        public static Assembly AssemblyByName(string name) {
            return SafeTests.Run(() => Assembly.Load(name), null);
        }

        public static List<Type> TypesForAssembly(string assemblyName) {
            return SafeTests.Run(() => {
                var a = AssemblyByName(assemblyName);
                return a.GetTypes().ToList();
            }, new List<Type>());
        }

        public static List<string> TypeNamesForAssembly(string assemblyName) {
            return SafeTests.Run(() => {
                var a = TypesForAssembly(assemblyName);
                return a.Select(t => t.FullName).ToList();
            }, new List<string>());
        }

        public static string Name =>
            GetStringTests.Head(GetClass.Namespace(typeof(GetSolutionTests)));
    }

}



