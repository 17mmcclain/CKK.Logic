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
using CKK.Logic.Exceptions;

namespace CKK.Logic.Models
{
    public class Store : Entity , IStore
    {
        public List<StoreItem> _items = new List<StoreItem>();

        public StoreItem AddStoreItem(Product prod, int quantity)
        {
            if (prod.Id == 0)
            {
                Random rand = new Random();
                int newId = rand.Next();
                if (newId != 0)
                {
                    prod.Id = newId;
                }
            }

            //no quantity given, means nothing to add

            if (quantity <= 0)
            {
                throw new InventoryItemStockTooLowException();
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
            //invalid quantity given
            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            //valid quantity given, enough available to remove, and matching ID
            if (quantity > 0)
            {
                StoreItem foundItem = FindStoreItemById(id);
                if (foundItem != null)
                {
                    if (foundItem.Quantity > quantity)
                    {
                        foundItem.Quantity = foundItem.Quantity - quantity;
                        return foundItem;
                    }
                    if (foundItem.Quantity <= quantity)
                    {
                        quantity = foundItem.Quantity;
                        foundItem.Quantity = foundItem.Quantity - quantity;
                        // _items.Remove(foundItem);
                        return foundItem;
                    }
                }
                if (foundItem == null)
                {
                    throw new ProductDoesNotExistException();
                }

            }
            return null;
        }

        public void DeleteStoreItem(int id)
        {
            StoreItem foundItem = FindStoreItemById(id);
            if (foundItem != null)
            {
                _items.Remove(foundItem);
            }
        }

        public List<StoreItem> GetStoreItems()
        {
            return _items;
        }

        public StoreItem FindStoreItemById(int id)
        {
            if (id < 0)
            {
                throw new InvalidIdException();
            }
            else
            {
                var returnedResult =
                from e in _items
                where e.Product.Id == id
                select e;

                if (returnedResult.FirstOrDefault() != null)
                {
                    return returnedResult.FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}

