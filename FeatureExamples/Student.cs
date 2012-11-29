namespace FeatureExamples
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int[] Scores { get; set; }

        public string ShowColor(IProduct product)
        {
            if (product.Color == "Red")
                return "Red";

            return string.Empty;
        }
        
        public string ShowColor1(Product product)
        {
            if (product.GetColor() == "Red")
                return "Red";

            return string.Empty;
        }
        
        public string ShowColor2(AbstractProduct product)
        {
            if (product.Color == "Red")
                return "Red";

            return string.Empty;
        }

        public string ShowPrice(Product product)
        {
            if (product.Price > 16)
                return "Expensive";

            return "Cheap";
        }
        
        public string ShowPrice1(IProduct product)
        {
            if (product.GetPrice() > 16)
                return "Expensive";

            return "Cheap";
        }
    }
}