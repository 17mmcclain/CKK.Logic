using CKK.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store : Entity
    {
        public List<StoreItem> _items = new List<StoreItem>();

        public Store(int _Id, string _Name)
            : base(_Id, _Name) { }

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            //no quantity given, means nothing to add.

            if (quantity <=0)
            {
                return null;
            }

            //elements in _items that are empty, meaning prod and quantity need added
            if (quantity > 0)
            {
                StoreItem foundItem = FindStoreItemById(prod.Id);

                if (foundItem != null)
                {
                    foundItem.Quantity = foundItem.Quantity + quantity;
                    return foundItem;
                }

                if (foundItem == null)
                {
                    StoreItem newItem = new StoreItem(prod, quantity);
                    _items.Add(newItem);
                    return newItem;
                }
            }  
            return null;
        }

        public StoreItem RemoveStoreItem(int id, int quantity)
        {
            if (quantity <= 0)
            {
                return null;
            }

            //valid quantity given, enough available to remove, and matching ID

            var quantityvalid = 
                from e in _items
                where e.Quantity > 0 && e.Quantity >= quantity
                select e;

            foreach (var element in quantityvalid)
            {
                if (element.Product.Id == id)
                {
                    element.Quantity = element.Quantity - quantity;
                    return element;
                }
            }

            //valid quantity given, but not enough to remove??

            var itemsabovegivenquantity =
                from e in _items
                where e.Quantity < quantity 
                select e;

            foreach (var element in itemsabovegivenquantity)
            {
                if (element.Product.Id == id)
                {
                    element.Quantity = 0;
                    return element;
                }
            }
            return null;
        }

        public List<StoreItem> GetStoreItems()
        {
            return _items;
        }

        public StoreItem FindStoreItemById(int id)
        {
            var returnedResult = 
                from e in _items
                where e.Product.Id == id
                select e;
            
            if (returnedResult.FirstOrDefault() != null)
            {
                return returnedResult.FirstOrDefault();
            }
            return null;
            
        }


    }
}
