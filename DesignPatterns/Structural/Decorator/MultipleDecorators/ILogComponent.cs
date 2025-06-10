namespace DesignPatterns.Structural.Decorator.MultipleDecorators
{
    public interface ILogComponent
    {
        void LogError(string error);
        void LogMessage(string message);
        void LogWarning(string warning);
    }
}