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
            if(quantity <= 0)
            {
                return null;
            }
            ShoppingCartItem cartItem = new ShoppingCartItem(prod, quantity);

            if(_product1 == null) //no existing item
            {
                _product1 = cartItem;
                return _product1;
            }
            if(_product2 == null)
            {
                _product2 = cartItem;
                return _product2;
            }
            if (_product3 == null)
            {
                _product3 = cartItem;
                return _product3;
            }

            if (_product1 != null && prod.GetId() == _product1.GetProduct().GetId()) //item exists and we change the quantity
            {
                _product1.SetQuantity(_product1.GetQuantity() + quantity);
                return _product1;
            }
            if (_product2 != null && prod.GetId() == _product2.GetProduct().GetId()) //item exists and we change the quantity
            {
                _product2.SetQuantity(_product2.GetQuantity() + quantity);
                return _product2;
            }
            if (_product2 != null && prod.GetId() == _product2.GetProduct().GetId()) //item exists and we change the quantity
            {
                _product3.SetQuantity(_product3.GetQuantity() + quantity);
                return _product3;
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
            if (_product1 != null && quantity <= _product1.GetQuantity() && prod.GetId() == _product1.GetProduct().GetId())
            {
                _product1.SetQuantity(_product1.GetQuantity() - quantity);
                return _product1;
            }
            if (_product2 != null && quantity <= _product2.GetQuantity() && prod.GetId() == _product2.GetProduct().GetId())
            {
                _product2.SetQuantity(_product2.GetQuantity() - quantity);
                return _product2;
            }
            if (_product3 != null && quantity <= _product3.GetQuantity() && prod.GetId() == _product3.GetProduct().GetId())
            {
                _product3.SetQuantity(_product3.GetQuantity() - quantity);
                return _product3;
            }

            //quantity > 0 given, but not enough to remove??
            if (_product1 != null && quantity > _product1.GetQuantity() && prod.GetId() == _product1.GetProduct().GetId())
            {
                quantity = _product1.GetQuantity();
                _product1.SetQuantity(_product1.GetQuantity() - quantity);
                return _product1;
            }
            if (_product2 != null && quantity > _product2.GetQuantity() && prod.GetId() == _product2.GetProduct().GetId())
            {
                quantity = _product2.GetQuantity();
                _product2.SetQuantity(_product2.GetQuantity() - quantity);
                return _product2;
            }
            if (_product3 != null && quantity > _product3.GetQuantity() && prod.GetId() == _product3.GetProduct().GetId())
            {
                quantity = _product3.GetQuantity();
                _product3.SetQuantity(_product3.GetQuantity() - quantity);
                return _product3;
            }
            return null;
        }

        public decimal GetTotal()
        {
            decimal total;
            total = _product1.GetTotal() + _product2.GetTotal() + _product3.GetTotal();
            return total;   
        }

        public ShoppingCartItem GetProduct(int prodNum)
        {
            if (prodNum == 1)
            {
                return _product1;
            }
            else if (prodNum == 2)
            {
                return _product2;
            }
            else if (prodNum == 3)
            {
                return _product3;
            }
            else
            {
                return null;
            }
            
        }
          


    }
}
