using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory
{
    public class Factory
    {
        public static IProduct CreateProduct(string type)
        {
            return type.ToLower() switch
            {
                "producta" => new ProductA(),
                "productb" => new ProductB(),
                _ => throw new ArgumentException("Invalid product type"),
            };
        }
    }
}
