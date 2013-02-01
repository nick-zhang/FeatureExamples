using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GarbageCollection
{
    [TestClass]
    public class GarbageCollectionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var temp = new Temp();
            Console.Out.WriteLine(sizeof(int));
        }
    }

    public class Temp
    {
        private int a;
    }
}
