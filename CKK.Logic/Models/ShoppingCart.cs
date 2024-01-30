using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    internal class ShoppingCart
    {
        private Customer _customer;
        private ShoppingCartItem _product1;
        private ShoppingCartItem _product2;
        private ShoppingCartItem _product3;

        public ShoppingCart(Customer cust)
        {
            _customer = cust;
        }

        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (_product1.GetProduct().GetId() == id)
            {
                return _product1;
            }

            else if (_product2.GetProduct().GetId() == id)
            {
                return _product2;
            }

            else if (_product3.GetProduct().GetId() == id)
            {
                return _product3;
            }
            return null;

        }

        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity > 0)
            {
                ShoppingCartItem foundItem = GetProductById(prod.GetId());
                if (foundItem == null)
                {
                    //no item was found - creating new one
                    return AddProduct(prod, quantity);
                }
                else
                {
                    //item found in variable founditem - add to quantity
                    return foundItem; 
                }
            }
            return null;
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }


    }
}
