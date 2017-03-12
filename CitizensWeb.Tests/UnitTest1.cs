using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CitizensWeb.Models;

namespace CitizensWeb.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddCitizen_ShouldReturnSameItem()
        {
            var testDbSet = new TestDbSet<citizen>();
            var item = GetCitizenExample();

            var result = testDbSet.Add(item);
            Assert.IsNotNull(result);
            Assert.AreEqual(result, item);
        }

        [TestMethod]
        public void AddCitizens_ShouldReturnAllCitizens()
        {
            var testDbSet = new TestDbSet<citizen>();
            DateTime date = new DateTime(1996, 4, 12);
            testDbSet.Add(new citizen() { CitizenId = 0, LastName = "Demo1", FirstName = "Demo1", BirthDate = date, City = "NizhniyNovgorod" });
            testDbSet.Add(new citizen() { CitizenId = 1, LastName = "Demo2", FirstName = "Demo2", BirthDate = date, City = "NizhniyNovgorod" });
            testDbSet.Add(new citizen() { CitizenId = 2, LastName = "Demo3", FirstName = "Demo3", BirthDate = date, City = "NizhniyNovgorod" });

            Assert.AreEqual(3, testDbSet.getCount());
        }

        [TestMethod]
        public void DeleteCitizen_ShouldReturnOK()
        {
            var testDbSet = new TestDbSet<citizen>();
            var item = GetCitizenExample();
            testDbSet.Add(item);
            var result = testDbSet.Remove(item);
            Assert.IsNotNull(result);
            Assert.AreEqual(result.CitizenId, item.CitizenId);
        }

        citizen GetCitizenExample()
        {
            DateTime date = new DateTime(1996, 4, 12);
            return new citizen() { CitizenId = 0, LastName = "Mitin", FirstName = "Anton", BirthDate = date, City = "NizhniyNovgorod" };
        }
    }
}
