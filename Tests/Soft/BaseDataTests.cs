using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using North.Tests.Soft;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Aids;
using North.Aids.Random;
using North.Data.Common;
using North.Domain.Common;

namespace North.Tests.Soft {

    public abstract class BaseDataTests<TData, TContext> : BasePagesTests<TData> 
        where TContext : DbContext 
        where TData: PeriodData {

        private TContext db;
        protected byte numberOfPages;
        protected int numberOfItems;
        protected byte numberOfItemsInLastPage;
        protected byte pageSize = North.Infra.Constants.DefaultPageSize;

        [TestInitialize] public async Task TestInitialize() {
            db = getContext<TContext>();
            item = randomItem();
            await addToDatabase(item);
        }

        protected async Task addToDatabase() {
            numberOfPages = GetRandom.UInt8(3, 10);
            numberOfItemsInLastPage = GetRandom.UInt8(2, pageSize);
            numberOfItems = (numberOfPages - 1) * pageSize + numberOfItemsInLastPage;
            for (var i = 1; i < numberOfItems; i++) await addToDatabase(randomItem());
        }

        protected async Task addToDatabase<T>(T d) {
            await db.AddAsync(d);
            await db.SaveChangesAsync();
        }

        protected virtual TData randomItem() {
            var d = (TData) GetRandom.Object(typeof(TData));
            if (d.ValidFrom != null) d.ValidFrom = ((DateTime) d.ValidFrom).Date;
            if (d.ValidTo != null) d.ValidTo = ((DateTime)d.ValidTo).Date;

            return d;
        }

        [TestMethod] public void CanDisplayDataTest() {
            sendRequest(pageUrl());
            if (isDetailsPage) dataInDetailsPage();
            if (isDeletePage) dataInDeletePage();
            if (isEditPage) dataInEditPage();
            if (isCreatePage) dataInCreatePage();
        }

        protected virtual void dataInDeletePage() => dataInDetailsPage();

        protected virtual void dataInCreatePage() => Assert.Inconclusive();

        protected virtual void dataInEditPage() => Assert.Inconclusive();

        protected virtual void dataInDetailsPage() => Assert.Inconclusive();

        [TestMethod] public async Task CanDeleteDataTest() {
           Assert.Inconclusive();
            //await addToDatabase();
            //var id = itemId(item);
            //var x = await db.FindAsync<TData>(toComposedId(id));
            //Assert.IsNotNull(x);
            //Assert.AreEqual(itemId(x), id);
            //db.Remove(item);
            //await db.SaveChangesAsync();
            //x = await db.FindAsync<TData>(toComposedId(id));
            //Assert.IsNull(x);
        }

        [TestMethod] public async Task CanCreateDataTest() {
            Assert.Inconclusive();
            //await addToDatabase();
            //item = randomItem();
            //var id = itemId(item);
            //var x = await db.FindAsync<TData>(toComposedId(id));
            //Assert.IsNull(x);
            //db.Add(item);
            //await db.SaveChangesAsync();

            //x = await db.FindAsync<TData>(toComposedId(id));
            //Assert.AreEqual(itemId(x), id);
            //Assert.IsNotNull(x);
        }

        protected static object[] toComposedId(string s) {
            var l = new List<object>();

            while (s.Contains('.')) {
                l.Add(s.GetHead());
                s = s.GetTail();
            }

            l.Add(s);

            return l.ToArray();
        }

        [TestMethod] public async Task CanEditDataTest() {
           Assert.Inconclusive();
            //await addToDatabase();
            //var id = itemId(item);
            //var x = await db.FindAsync<TData>(toComposedId(id));
            //Assert.IsNotNull(x);
            //testArePropertyValuesEqual(x, item);
            //changeValuesExceptId(item);
            //testArePropertyValuesEqual(x, item);
            //Assert.AreEqual(itemId(x), itemId(item));
            //db.Update(item);
            //await db.SaveChangesAsync();

            //x = await db.FindAsync<TData>(toComposedId(id));
            //Assert.IsNotNull(x);
            //testArePropertyValuesEqual(x, item);
        }

        protected abstract void changeValuesExceptId(TData data);

    }

}
