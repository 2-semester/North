using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Abc.Tests.Soft;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids.Random;
using North.Data.Common;
using North.Domain.Common;
using North.Soft;

namespace North.Tests.Soft {

    public abstract class BaseSoftTests : BaseTests {

        protected static readonly TestHost<Startup> host;
        protected static readonly HttpClient client;

        static BaseSoftTests() {
            host = new TestHost<Startup>();
            client = host.CreateClient();
        }

        protected static async Task itemFromRepository<TRepository, TObject, TData>(string id,
            Func<TData, TObject> create, Func<TObject> getObj)
            where TObject : Entity<TData>
            where TRepository : IRepository<TObject>
            where TData : UniqueEntityData, new() {
            var r = GetRepository.Instance<TRepository>();
            var d = GetRandom.Object<TData>();
            d.Id = id;
            await r.Add(create(d));
            testArePropertyValuesEqual(d, getObj().Data);

        }
        protected static async Task listFromRepository<TRepository, TObject, TData>(
            object o, string name, Action<TData> setId, Func<TData, TObject> create)
            where TRepository : IRepository<TObject>
            where TObject : PeriodData {
            var count = GetRandom.UInt8(10, 30);
            var r = GetRepository.Instance<TRepository>();

            for (var i = 0; i < count; i++) {
                var d = GetRandom.Object<TData>();
                if (i % 4 == 0) setId(d);
                await r.Add(create(d));
            }

            var t = isReadOnlyProperty(o, name) as IReadOnlyList<TObject>;
            Assert.IsNotNull(t);
            Assert.AreEqual(Math.Ceiling(count / 4.0), t.Count);
        }

        protected static void isReadOnlyProperty(object o, string name, object expected) {
            var actual = isReadOnlyProperty(o, name);
            Assert.AreEqual(expected, actual);
        }
 
        protected static object isReadOnlyProperty(object o, string name) {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.IsFalse(property.CanWrite);
            Assert.IsTrue(property.CanRead);

            return property.GetValue(o);
        }


    }

}
