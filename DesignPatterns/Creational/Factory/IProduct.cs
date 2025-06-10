namespace DesignPatterns.Creational.Factory
{
    public interface IProduct
    {
        string Name { get; }
        string Description { get; }
        void Use();
    }
}