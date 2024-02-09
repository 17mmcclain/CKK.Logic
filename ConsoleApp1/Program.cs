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
            Store store = new Store();
            Product newproduct = new Product();
            StoreItem storeitem = store.AddStoreItem(newproduct, 20);


            Console.WriteLine(storeitem.Product);

        }
    }
}
