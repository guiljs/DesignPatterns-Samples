using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.MultipleDecorators
{
    public class LogComponent : ILogComponent
    {
        private readonly string _prefix;
        public LogComponent(string prefix = "Log")
        {
            _prefix = prefix;
        }
        public void LogMessage(string message)
        {
            Console.WriteLine($"{_prefix} Message: {message}");
        }

        public void LogWarning(string warning)
        {
            Console.WriteLine($"{_prefix} ***** Warning: {warning} *****");
        }
        public void LogError(string error)
        {
            Console.WriteLine($"{_prefix} Error: {error}");
        }
    }

    public abstract class LogDecorator : ILogComponent
    {
        protected readonly ILogComponent _logComponent;

        protected LogDecorator(ILogComponent logComponent)
        {
            _logComponent = logComponent;
        }

        public virtual void LogError(string error)
        {
            _logComponent.LogError(error);
        }

        public virtual void LogMessage(string message)
        {
            _logComponent.LogMessage(message);
        }

        public virtual void LogWarning(string warning)
        {
            _logComponent.LogWarning(warning);
        }
    }

    public class EmailNotificationDecorator : LogDecorator
    {
        public EmailNotificationDecorator(ILogComponent logComponent) : base(logComponent)
        {
        }

        public override void LogWarning(string warning)
        {
            base.LogWarning(warning);
            NotifyByEmail(warning);
        }

        private void NotifyByEmail(string warning)
        {
            Console.WriteLine($"Sending email notification for warning: {warning}");
        }
    }
}
