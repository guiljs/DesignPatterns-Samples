namespace DesignPatterns.Creational.Factory
{
    public class ProductB : IProduct
    {
        public string Name => "Product B";

        public string Description => "This is Product B, another type of product in the factory pattern.";

        public void Use()
        {
            Console.WriteLine("Using Product B.");
        }
    }
}