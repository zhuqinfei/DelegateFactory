using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            WrapFactory wrapfactory = new WrapFactory();
            ProductFactory productFactory = new ProductFactory();

            Func<Product> func1 = new Func<Product>(productFactory.MakePisha);

            Box box = wrapfactory.MakeBox(func1);

            Console.WriteLine(box.product.Name);

            
        }
    }
    class Product
    {
        public string Name { get; set; }
    }
    class Box
    {
        public Product product;
    }
    class WrapFactory
    {
        public Box MakeBox(Func<Product> product)
        {
            Box box = new Box();
            box.product = product.Invoke();
            return box;
        }

    }
    class ProductFactory
    {
       public Product MakePisha()
        {
            Product product = new Product();
            product.Name = "pisha";
            return product;
        }
    }
}
