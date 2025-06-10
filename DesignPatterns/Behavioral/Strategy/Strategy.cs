using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy
{
    internal class Strategy
    {
        public interface IDiscountStrategy
        {
            decimal ApplyDiscount(decimal price);
        }

        public class NoDiscountStrategy : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price)
            {
                return price;
            }
        }

        public class EmployeeDiscountStrategy : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price)
            {
                return price * 0.55m;
            }
        }

        public class VipDiscountStrategy : IDiscountStrategy
        {
            public decimal ApplyDiscount(decimal price)
            {
                return price * 0.7m;
            }
        }

        public class  SuperDiscountStrategy : IDiscountStrategy
        {
            public decimal ApplyDiscount (decimal price)
            {
                Console.WriteLine("****** Applying super discount strategy. *******");
                return price * 0.95m;
            }

        }

        public class AgeDiscountStrategy : IDiscountStrategy
        {
            private readonly int _age;

            public AgeDiscountStrategy(int age)
            {
                _age = age;
            }

            public decimal ApplyDiscount(decimal price)
            {
                if (_age < 18)
                {
                    return price * 0.9m; // 10% discount for minors
                }
                else if (_age >= 60)
                {
                    return price * 0.85m; // 15% discount for seniors
                }
                return price; // No discount for others
            }
        }
    }
}
