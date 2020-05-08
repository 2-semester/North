using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Data.Event;
using North.Domain.Event;
using North.Facade.Event;
using North.Tests;

namespace North.Tests.Aids.Reflection
{

    [TestClass]
    public class GetMemberTests : BaseTests
    {

        [TestInitialize] public void TestInitialize() => type = typeof(GetMember);

        [TestMethod]
        public void NameTest()
        {
            Assert.AreEqual("Data", GetMember.Name<EventDomain>(o => o.Data));
            Assert.AreEqual("Name", GetMember.Name<EventData>(o => o.Name));
            Assert.AreEqual("NameTest", GetMember.Name<GetMemberTests>(o => o.NameTest()));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Func<EventData, object>>)null));
            Assert.AreEqual(string.Empty, GetMember.Name((Expression<Action<EventData>>)null));
        }

        [TestMethod]
        public void DisplayNameTest()
        {
            Assert.AreEqual("Data", GetMember.DisplayName<EventDomain>(o => o.Data));
            Assert.AreEqual("Valid from",
                GetMember.DisplayName<EventView>(o => o.ValidFrom));
            Assert.AreEqual("Name", GetMember.DisplayName<EventView>(o => o.Name));
            Assert.AreEqual("Valid to", GetMember.DisplayName<EventView>(o => o.ValidTo));
            Assert.AreEqual(string.Empty, GetMember.DisplayName<EventView>(null));
            //Impossible to use for methods
            //Assert.AreEqual(string.Empty, GetMember.DisplayName<GetMemberTests>(o => o.NameTest()));
        }

    }

}