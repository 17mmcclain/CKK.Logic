using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Product : Entity
    {
        private decimal _price;

        public Product (int _Id, string _Name, decimal price)
            : base (_Id, _Name)
        {
            Price = price;
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
