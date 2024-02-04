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
        //private ShoppingCartItem _product1;
        //private ShoppingCartItem _product2;
        //private ShoppingCartItem _product3;
        public List<ShoppingCartItem> _products;

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
            if(quantity <= 0)
            {
                return null;
            }
            ShoppingCartItem cartItem = new ShoppingCartItem(prod, quantity);

            var emptyelementinitems =
                from e in _products
                where e == null
                select e;

            foreach (var element in emptyelementinitems)
            {
                return cartItem;
            }

            var notemptyelementinitems = 
                from e in _products
                where e != null
                select e;

            foreach (var element in  notemptyelementinitems)
            {
                if (element != null && prod.GetId() == element.GetProduct().GetId())
                {
                    element.SetQuantity(element.GetQuantity() + quantity);
                    return element;
                }
            }
            return null;
        }

        public ShoppingCartItem AddProduct(Product prod)
        {
            return AddProduct(prod, 1);
        }

        public ShoppingCartItem RemoveProduct(Product prod, int quantity)
        {
            //invalid quantity given
            if (quantity <= 0)
            {
                return null;
            }

            //valid quantity given, enough available to remove, and matching ID
            var validquantitytoremove =
                from e in _products
                where e.GetQuantity() > 0 && e.GetQuantity() <= quantity
                select e;

            foreach (var element in validquantitytoremove)
            {
                if (element.GetProduct().GetId() == prod.GetId()) 
                { 
                    element.SetQuantity(element.GetQuantity() - quantity);
                    return element;
                }
            }

            //valid quantity given, not enough to remove, matching ID
            var notenoughtoremove =
                from e in _products
                where e.GetQuantity() < quantity
                select e;

            foreach (var element in notenoughtoremove)
            {
                if (element.GetProduct().GetId() == prod.GetId())
                {
                    element.SetQuantity(0);
                    return element;
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
                sum += element.GetTotal();
                return sum;
            }
            return 0;
        }

        public List<ShoppingCartItem> GetProduct()
        {
            var foundproducts = 
                from e in _products     
                where e != null
                select e;
            if (foundproducts.Any())
            {
                List<ShoppingCartItem> listoffound = foundproducts.ToList();
                return listoffound;
            }
            return null;


            //if (prodNum == 1)
            //{
            //    return _product1;
            //}
            //else if (prodNum == 2)
            //{
            //    return _product2;
            //}
            //else if (prodNum == 3)
            //{
            //    return _product3;
            //}
            //else
            //{
            //    return null;
            //}

        }
          


    }
}
