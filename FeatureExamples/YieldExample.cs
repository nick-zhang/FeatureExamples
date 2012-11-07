using System;
using System.Collections.Generic;

namespace FeatureExamples
{
    public class YieldExample
    {
        public IEnumerable<int> WithNoYield()
        {
            IList<int> list = new List<int>();
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                if (i > 2)
                    list.Add(i);
            }
            return list;
        }

        public IEnumerable<int> WithYield()
        {
            for (var i = 0; i < 5; i++)
            {
                Console.WriteLine(i);
                if (i > 2)
                    yield return i;
            }
        }
    }
}