using System;

namespace FeatureExamples
{
    public class Product : AbstractProduct
    {
        public string Color1 { get; set; }
        public double Price { get; set; }

        public override string Color
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override double GetPrice()
        {
            return Price;
        }

        public string ProducedLocation;
        public int ProducedYear;

        public string GetColor()
        {
            return Color;
        }

        public object GetColorAndPrice()
        {
            return new { Color, Price};
        }
    }
}