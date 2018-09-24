using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileManager;

namespace ADONETTEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserRepository user = new UserRepository();

            var q = user.Get("123", "123");

            Assert.IsNull(q);
        }
    }
}
