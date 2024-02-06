using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CKK.Logic.Models;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            ShoppingCart testing = new ShoppingCart(customer);
            Product product1 = new Product();
            product1.SetId(1);
            product1.SetName("Apples");
            product1.SetPrice(2);
            Product product2 = new Product();
            product2.SetId(2);
            product2.SetName("Pears");
            product2.SetPrice(3);


            testing.AddProduct(product1, 3);
            testing.AddProduct(product2, 3);

            Console.WriteLine($"product 1  -  {product1.GetName()} should not be equal to {product2.GetName()}");
            Console.WriteLine($"product 2  -  {product1.GetId()} should also not be equal to {product2.GetId()}");

            Console.WriteLine("Getting product1 by ID");
            Console.WriteLine($"{testing.GetProductById(1).GetProduct().GetName()} - {testing.GetProductById(1).GetQuantity()}");

            Console.WriteLine("Testing removal of 4 out of 3.");
            testing.RemoveProduct(1, 4);

            Console.WriteLine(testing.GetProducts().Count());

            Console.WriteLine($"Should be equal to {product2.GetPrice()} times {testing.GetProductById(2).GetQuantity()}");
            Console.WriteLine(testing.GetTotal());
            Product product3 = new Product();
            product3.SetId(7);
            product3.SetName("pickles");
            product3.SetPrice(8);

            testing.AddProduct(product3, 7);

            Console.WriteLine(testing.GetProducts().Count());
            Console.WriteLine($"Should be equal to {product2.GetPrice()} times {testing.GetProductById(2).GetQuantity()} + {product3.GetPrice()} times {testing.GetProductById(7).GetQuantity()}");
            Console.WriteLine(testing.GetTotal());

            //ShoppingCartItem item = new ShoppingCartItem(7, )
        }
    }
}
