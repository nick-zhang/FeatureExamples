namespace FeatureExamples
{
    public abstract class AbstractProduct : IProduct
    {
        public abstract string Color { get; set; }
        public string Name { get; set; }

        public abstract double GetPrice();
    }
}