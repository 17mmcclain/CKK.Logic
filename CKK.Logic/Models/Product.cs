using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    internal class Product
    {
        private int _id;
        private string _name;
        private decimal _price;

        public int GetId()
        {
            return _id;
        }

        public int SetId(int id)
        {
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public string SetName(string name)
        {
            _name = name;
        }

        public decimal GetPrice()
        {
            return _price;
        }

        public decimal SetPrice(decimal price)
        {
            _price = price;
        }
    }
}
