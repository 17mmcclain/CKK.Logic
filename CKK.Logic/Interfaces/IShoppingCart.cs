using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public interface IShoppingCart
    {
        public int GetCustomerId();

        public ShoppingCartItem GetProductById(int id);


        public ShoppingCartItem AddProduct(Product prod, int quantity);

        public ShoppingCartItem AddProduct(Product prod);

        public ShoppingCartItem RemoveProduct(int id, int quantity);

        public decimal GetTotal();
        

    public List<ShoppingCartItem> GetProducts();
    }
}
