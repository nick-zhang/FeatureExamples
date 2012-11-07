using System;

namespace FeatureExamples
{
    public static class DateTimeExtension
    {
        public static string YYYY_MM_DD(this DateTime datetime)
        {
            return datetime.ToString("yyyy_MM_dd");
        }
    }
}