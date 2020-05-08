﻿using System;
using System.Collections;
using System.Linq;

namespace North.Aids {
    public static class SetRandomTests {
        public static void Values(object o) {
            if (o is null) return;
            if (o is IList list) setValuesForList(list);
            else setValuesForProperties(o);
        }
        private static void setValuesForProperties(object o) {
            if (o is null) return;
            var t = o.GetType();
            var properties = GetClassTests.Properties(t);
            foreach (var p in properties) {
                if (!p.CanWrite) continue;
                if (p.PropertyType.Name == t.Name) continue;
                var v = GetRandomTests.Value(p.PropertyType);
                p.SetValue(o, v);
            }
        }

        private static void setValuesForList(IList l) {
            if (l is null) return;
            var t = getListElementsType(l);
            for (var c = 0; c <= GetRandomTests.UInt8(3, 5); c++) {
                var v = GetRandomTests.Value(t);
                l.Add(v);
            }
        }
        private static Type getListElementsType(IList list) {
            return SafeTests.Run(() => {
                var t = list.GetType();
                var types =
                (from method in t.GetMethods()
                    where method.Name == "get_Item"
                    select method.ReturnType
                ).Distinct().ToArray();
                return types[0];
            }, null);
        }
    }
}



