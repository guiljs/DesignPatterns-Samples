namespace DesignPatterns.Creational.Factory
{
    public class ProductA : IProduct
    {
        public string Name => "Product A";

        public string Description => "This is Product A, a type of product in the factory pattern.";

        public void Use()
        {
            Console.WriteLine("Using Product A.");
        }
    }
}