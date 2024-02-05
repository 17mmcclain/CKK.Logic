using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class ShoppingCart
    {
        private Customer _customer;
        public List<ShoppingCartItem> _products;

        public ShoppingCart(Customer cust)
        {
            _customer = cust;
            _products = new List<ShoppingCartItem>();
        }

        public int GetCustomerId()
        {
            return _customer.GetId();
        }

        public ShoppingCartItem GetProductById(int id)
        {
            var returnedwithId = 
                from e in _products
                where e.GetProduct().GetId() == id
                select e;

            if (returnedwithId.FirstOrDefault() != null)
            {
                return returnedwithId.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

      
        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                return null;
            }
            ShoppingCartItem foundItem = GetProductById(prod.GetId());

            if (foundItem != null)
            {
                foundItem.SetQuantity(foundItem.GetQuantity() + quantity);
                return foundItem;
            }
            else
            {
                ShoppingCartItem newItem = new ShoppingCartItem(prod, quantity);
                _products.Add(newItem);
                return newItem;
            }
            return null;
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem RemoveProduct(int id, int quantity)
        {
            //invalid quantity given
            if (quantity <= 0)
            {
                return null;
            }

            //valid quantity given, enough available to remove, and matching ID
            if (quantity > 0)
            {
                var validquantitytoremove =
                    from e in _products
                    where e.GetQuantity() >= quantity
                    select e;

                foreach (var element in validquantitytoremove)
                {
                    if (element.GetProduct().GetId() == id)
                    {
                        element.SetQuantity(element.GetQuantity() - quantity);
                        return element;
                    }
                }

                //valid quantity given, not enough to remove, matching ID
                var notenoughtoremove =
                    from e in _products
                    where e.GetQuantity() > quantity
                    select e;

                foreach (var element in notenoughtoremove)
                {
                    if (element.GetProduct().GetId() == id)
                    {
                        element.SetQuantity(0);
                        return element;
                    }
                }
            }

            return null;
        }

        public decimal GetTotal()
        {
            decimal sum = 0;
            var result =
                from e in _products
                where e.GetQuantity() > 0
                select e;
            foreach (var element in result)
            {
                sum = sum + element.GetTotal();
                return sum;
            }
            return 0;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return _products;
        }
    }
}
