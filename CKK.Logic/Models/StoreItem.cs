using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace CKK.Logic.Models
{
    public class StoreItem
    {
        private Product _product;
        private int _quantity;

        public StoreItem(Product product, int quantity)
        {
            _product = product;
            _quantity = quantity;
        }
        public int GetQuantity()
        {
            return _quantity;
        }

        public void SetQuantity(int quantity)
        {
            _quantity = quantity;
        }

        public Product GetProduct()
        {
            return _product;
        }

        public void SetProduct(Product product)
        {
            _product = product;
        }
    }
}
