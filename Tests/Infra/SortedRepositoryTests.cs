using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Aids.Random;
using North.Domain.Event;
using North.Infra;
using North.Data.Event;

namespace North.Tests.Infra
{
    [TestClass]
    public class SortedRepositoryTests : AbstractClassTests<SortedRepository<EventDomain, EventData>,
        BaseRepository<EventDomain, EventData>>
    {
        private class testClass : SortedRepository<EventDomain, EventData>
        {
            public testClass(DbContext c, DbSet<EventData> s) : base(c, s)
            {
            }

            protected internal override EventDomain toDomainObject(EventData d) => new EventDomain(d);

            protected override async Task<EventData> getData(string id)
            {
                await Task.CompletedTask;
                return new EventData();
            }

            protected override string getId(EventDomain entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<NorthDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new NorthDbContext(options);
            obj = new testClass(c, c.Events);
        }

        [TestMethod]
        public void SortOrderTest()
        {
            isNullableProperty(() => obj.SortOrder, x => obj.SortOrder = x);
        }

        [TestMethod]
        public void DescendingStringTest()
        {
            var propertyName = GetMember.Name<testClass>(x => x.DescendingString);
            isReadOnlyProperty(obj, propertyName, "_desc");
        }
        [TestMethod]
        public void SetSortingTest()
        {
            void test(IQueryable<EventData> d, string sortOrder)
            {
                obj.SortOrder = sortOrder + obj.DescendingString;
                var set = obj.addSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                var str = set.Expression.ToString();
                Assert.IsTrue(str
                    .Contains($"North.Data.Event.EventData]).OrderByDescending(x => Convert(x.{sortOrder}, Object)"));
                obj.SortOrder = sortOrder;
                set = obj.addSorting(d);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set);
                str = set.Expression.ToString();
                Assert.IsTrue(str.
                    Contains($"North.Data.Event.EventData]).OrderBy(x => Convert(x.{sortOrder}, Object)"));
            }

            Assert.IsNull(obj.addSorting(null));
            IQueryable<EventData> data = obj.dbSet;
            obj.SortOrder = null;
            Assert.AreEqual(data, obj.addSorting(data));
            test(data, GetMember.Name<EventData>(x => x.Definition));
            test(data, GetMember.Name<EventData>(x => x.Name));
            test(data, GetMember.Name<EventData>(x => x.Id));
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            string s;
            testCreateExpression(GetMember.Name<EventData>(x => x.Id));
            testCreateExpression(GetMember.Name<EventData>(x => x.Name));
            testCreateExpression(GetMember.Name<EventData>(x => x.Definition));
            testCreateExpression(GetMember.Name<EventData>(x => x.EventDate));
            testCreateExpression(GetMember.Name<EventData>(x => x.SportCategoryId));
            testCreateExpression(GetMember.Name<EventData>(x => x.TypeId));
            testCreateExpression(GetMember.Name<EventData>(x => x.OrganizationId));
            testCreateExpression(GetMember.Name<EventData>(x => x.EventListId));

            testCreateExpression(s = GetMember.Name<EventData>(x => x.Id), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<EventData>(x => x.Name), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<EventData>(x => x.Definition), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<EventData>(x => x.EventDate), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<EventData>(x => x.SportCategoryId), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<EventData>(x => x.TypeId), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<EventData>(x => x.OrganizationId), s + obj.DescendingString);
            testCreateExpression(s = GetMember.Name<EventData>(x => x.EventListId), s + obj.DescendingString);
            testNullExpression(GetRandom.String());
            testNullExpression(string.Empty);
            testNullExpression(null);
        }

        private void testNullExpression(string name)
        {
            obj.SortOrder = name;
            var lambda = obj.createExpression();
            Assert.IsNull(lambda);
        }

        private void testCreateExpression(string expected, string name = null)
        {
            name ??= expected;//kui name on tühi, võta expected
            obj.SortOrder = name;
            var lambda = obj.createExpression();
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<EventData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<EventData>(x => x.EventDate);
            var property = typeof(EventData).GetProperty(name);
            var lambda = obj.lambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<EventData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }

        [TestMethod]
        public void FindPropertyTest()
        {
            string s;
            void test(PropertyInfo expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.findProperty());
            }
            test(null, GetRandom.String());
            test(null, null);
            test(null, string.Empty);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.Name)), s);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.EventDate)), s);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.SportCategoryId)), s);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.Definition)), s);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.TypeId)), s);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.Id)), s);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.OrganizationId)), s);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.EventListId)), s);

            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.Name)),
                s + obj.DescendingString);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.EventDate)),
                s + obj.DescendingString);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.SportCategoryId)),
                s + obj.DescendingString);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.Definition)),
                s + obj.DescendingString);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.TypeId)),
                s + obj.DescendingString);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.Id)),
                s + obj.DescendingString);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.OrganizationId)),
                s + obj.DescendingString);
            test(typeof(EventData).GetProperty(s = GetMember.Name<EventData>(x => x.EventListId)),
                s + obj.DescendingString);
        }

        [TestMethod]
        public void GetNameTest()
        {
            string s;
            void test(string expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.getName());
            }
            test(s = GetRandom.String(), s);
            test(s = GetRandom.String(), s + obj.DescendingString);
            test(string.Empty, string.Empty);
            test(string.Empty, null);
        }
        [TestMethod]
        public void SetOrderByTest()
        {
            void test(IQueryable<EventData> d, Expression<Func<EventData, object>> e, string expected)
            {
                obj.SortOrder = GetRandom.String() + obj.DescendingString;
                var set = obj.addOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set); //data ja set ei ole võrdsed
                Assert.IsTrue(set.Expression.ToString()
                    .Contains($"North.Data.Event.EventData]).OrderByDescending({expected})"));
                obj.SortOrder = GetRandom.String();
                set = obj.addOrderBy(d, e);
                Assert.IsNotNull(set);
                Assert.AreNotEqual(d, set); //data ja set ei ole võrdsed
                Assert.IsTrue(set.Expression.ToString().
                    Contains($"North.Data.Event.EventData]).OrderBy({expected})"));
            }
            Assert.IsNull(obj.addOrderBy(null, null));
            IQueryable<EventData> data = obj.dbSet;
            Assert.AreEqual(data, obj.addOrderBy(data, null));
            test(data, x => x.Definition, "x => x.Definition");
            test(data, x => x.Id, "x => x.Id");
            test(data, x => x.Name, "x => x.Name");
            test(data, x => x.EventDate, "x => Convert(x.EventDate, Object)");
            test(data, x => x.SportCategoryId, "x => x.SportCategoryId");
            test(data, x => x.TypeId, "x => x.TypeId");
            test(data, x => x.OrganizationId, "x => x.OrganizationId");
            test(data, x => x.EventListId, "x => x.EventListId"); 
        }
        [TestMethod]
        public void IsDescendingTest()
        {
            void test(string sortOrder, bool expected)
            {
                obj.SortOrder = sortOrder;
                var actual = obj.isDecending();
                Assert.AreEqual(expected, actual);
            }
            test(GetRandom.String(), false);
            test(GetRandom.String() + obj.DescendingString, true);
            test(string.Empty, false);
            test(null, false);
        }
    }
}
