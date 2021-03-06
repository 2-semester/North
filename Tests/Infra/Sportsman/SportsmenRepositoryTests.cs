﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Sportsman;
using North.Domain.Sportsman;
using North.Infra;
using North.Infra.Sportsman;

namespace North.Tests.Infra.Sportsman
{
    [TestClass]
    public class SportsmenRepositoryTests : RepositoryTests<SportsmenRepository, SportsmanDomain, SportsmanData>
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<NorthDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;
            db = new NorthDbContext(options);
            dbSet = ((NorthDbContext)db).Sportsmen;
            obj = new SportsmenRepository((NorthDbContext)db);
            base.TestInitialize();
        }

        protected override Type getBaseType()
        {
            return typeof(UniqueEntityRepository<SportsmanDomain, SportsmanData>);
        }

        protected override string getId(SportsmanData d) => d.Id;

        protected override SportsmanDomain getObject(SportsmanData d) => new SportsmanDomain(d);

        protected override void setId(SportsmanData d, string id) => d.Id = id;
    }
}
