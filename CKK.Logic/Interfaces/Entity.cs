using CKK.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKK.Logic.Interfaces
{
    public abstract class Entity
    {

        public Entity (int _Id,  string _Name)
        {
            Id = _Id;
            Name = _Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
