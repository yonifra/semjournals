using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEMJournals.Server;

namespace SEMJournals.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var service = new Service1();
            var journals = service.GetAllJournals();

            Assert.IsNotNull(journals);
        }
    }
}
