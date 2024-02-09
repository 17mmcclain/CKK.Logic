using CKK.Logic.Exceptions;
using CKK.Logic.Interfaces;
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
    public class ShoppingCart : IShoppingCart
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
            return _customer.Id;
        }

        public ShoppingCartItem GetProductById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }
            else
            {
                var returnedwithId =
                from e in _products
                where e.Product.Id == id
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
            
        }


        public ShoppingCartItem AddProduct(Product prod, int quantity)
        {
            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
            }
            ShoppingCartItem foundItem = GetProductById(prod.Id);

            if (foundItem != null)
            {
                foundItem.Quantity = foundItem.Quantity + quantity;
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
                throw new ArgumentOutOfRangeException();
            }

            //valid quantity given, enough available to remove, and matching ID
            if (quantity > 0)
            {
                ShoppingCartItem foundItem = GetProductById(id);

                if (foundItem != null)
                {
                    if (foundItem.Quantity > quantity)
                    {
                        foundItem.Quantity = foundItem.Quantity - quantity;
                        return foundItem;
                    }
                    if (foundItem.Quantity <= quantity)
                    {
                        quantity = foundItem.Quantity;
                        foundItem.Quantity = foundItem.Quantity - quantity;
                        _products.Remove(foundItem);
                        return foundItem;
                    }
                }
                if (foundItem == null)
                {
                    throw new ProductDoesNotExistException();
                }

            }

            return null;
        }

        public decimal GetTotal()
        {
            var results =
                from e in _products
                select e.GetTotal();
            foreach (var item in results)
            {
                return results.Sum();
            }
            return 0;
        }

        public List<ShoppingCartItem> GetProducts()
        {
            return _products;
        }
    }
}
