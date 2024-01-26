using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    internal class Customer
    {
        private int _id;
        private string _name;
        private string _address;

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

        public string GetAddress()
        {
            return _address;
        }

        public string SetAddress(string address)
        {
            _address = address;
        }
    }
}
