using CKK.Logic.Interfaces;
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
    public class StoreItem : InventoryItem
    {

        public StoreItem(Product product, int quantity) 
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
