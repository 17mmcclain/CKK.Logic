using CKK.Logic.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCartItem : InventoryItem
    {
        public ShoppingCartItem(Product product, int quantity)
        { 
            Product = product;
            Quantity = quantity;
        }


        public decimal GetTotal()
        {
            return base.Product.Price * base.Quantity;
        }
    }
}
