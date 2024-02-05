using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CKK.Logic.Models
{
    public class Store
    {
        private int _id;
        private string? _name;
        public List<StoreItem> _items = new List<StoreItem>();

        public int GetId()
        {
            return _id;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name) 
        {
            _name = name;
        }

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
                StoreItem foundItem = FindStoreItemById(prod.GetId());

                if (foundItem != null)
                {
                    foundItem.SetQuantity(foundItem.GetQuantity() + quantity);
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
                where e.GetQuantity() > 0 && e.GetQuantity() >= quantity
                select e;

            foreach (var element in quantityvalid)
            {
                if (element.GetProduct().GetId() == id)
                {
                    element.SetQuantity(element.GetQuantity() - quantity);
                    return element;
                }
            }

            //valid quantity given, but not enough to remove??

            var itemsabovegivenquantity =
                from e in _items
                where e.GetQuantity() < quantity 
                select e;

            foreach (var element in itemsabovegivenquantity)
            {
                if (element.GetProduct().GetId() == id)
                {
                    element.SetQuantity(0);
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
                where e.GetProduct().GetId() == id
                select e;
            
            if (returnedResult.FirstOrDefault() != null)
            {
                return returnedResult.FirstOrDefault();
            }
            return null;
            
        }


    }
}
