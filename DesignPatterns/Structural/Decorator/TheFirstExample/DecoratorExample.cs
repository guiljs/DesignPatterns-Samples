using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Structural.Decorator.TheFirstExample
{
    public class MyOldComponentThatICantChange : IMyOldComponentThatICantChange
    {
        public virtual string GetDescription()
        {
            return "This is the original component.";
        }
    }

    public class MyDecorator : IMyOldComponentThatICantChange
    {
        private readonly IMyOldComponentThatICantChange _component;

        public MyDecorator(IMyOldComponentThatICantChange component)
        {
            _component = component;
        }

        public virtual string GetDescription()
        {
            return $"{_component.GetDescription()} Decorated with additional functionality.";
        }
    }
}
