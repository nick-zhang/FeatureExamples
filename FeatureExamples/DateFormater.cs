using System;

namespace FeatureExamples
{
    public class DateFormater
    {
        public string YYYY_MM_DD(DateTime dateTime)
        {
            return dateTime.ToString("yyyy_MM_dd");
        }
    }
}