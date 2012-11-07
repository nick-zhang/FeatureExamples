using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FeatureExamplesTest
{
    [TestClass]
    public class LinqTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string[] names1 = { "nick", "david", "carry" };
            string[] names2 = { "carry", "david" };
            var selectedNames = new List<string>();

            foreach (var name in names2)
            {
                if (names1.Contains(name))
                {
                    selectedNames.Add(name);
                }
            }

            
            foreach (var name in selectedNames)
            {
                Console.Out.WriteLine();
            }
        }
    }
}
