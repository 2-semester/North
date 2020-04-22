using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using North.Data.Common;
using North.Data.Sportsman;

namespace North.Tests.Data.Sportsman
{
    [TestClass]
    public abstract class SportsmanDataTests: SealedClassTests<SportsmanData,NamedEntityData>
    {
        //public DateTime DateOfBirth { get; set; }
    }
}
