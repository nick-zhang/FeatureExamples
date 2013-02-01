using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatureExamplesTest
{
    [TestClass]
    public class SealedTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }

    internal class X
    {
        protected virtual void F()
        {
            Console.WriteLine("X.F");
        }

        protected virtual void F2()
        {
            Console.WriteLine("X.F2");
        }
    }

    internal abstract class Y : X
    {
        protected virtual void F()
        {
            Console.WriteLine("Y.F");
        }

        protected override void F2()
        {
            Console.WriteLine("X.F3");
        }

        protected abstract void F3();
    }

    internal class Z : Y
    {
        // Attempting to override F causes compiler error CS0239.
        protected override void F()
        {
            Console.WriteLine("C.F");
        }

        // Overriding F2 is allowed.
        protected override void F2()
        {
            Console.WriteLine("Z.F2");
        }

        protected override void F3()
        {
            throw new NotImplementedException();
        }
    }
}