using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Customer : Entity
    {
        private string _address;
        
        public Customer(int _Id, string _Name, string address)
            : base (_Id, _Name)
        { 
            Address = address;
        }
        public string Address
        { get; set;  }
    }
}
