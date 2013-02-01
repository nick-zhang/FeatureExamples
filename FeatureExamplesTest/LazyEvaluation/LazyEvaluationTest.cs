using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatureExamplesTest.LazyEvaluation
{
    [TestClass]
    public class LazyEvaluationTest
    {
        [TestMethod]
        public void ShouldWorkAsEagerEvaluationWithVariableAsParameter()
        {
            DoSomething(0, BigCalculation());
        }

        [TestMethod]
        public void ShouldWorkAsLazyEvaluationWithFunctionAsParameter()
        {
            HigherOrderDoSomething(() => 0, BigCalculation);
        }

        private static int BigCalculation()
        {
            Console.WriteLine("BigCalculation called ");
            return 42;
        }

        private static void DoSomething(int a, int b)
        {
            Console.WriteLine("DoSomething called");
            if (a != 0)
                Console.WriteLine(b);
        }

        private static void HigherOrderDoSomething(Func<int> a, Func<int> b)
        {
            Console.WriteLine("HigherOrderDoSomething called");
            if (a() != 0)
                Console.WriteLine(b());
        }
    }
}