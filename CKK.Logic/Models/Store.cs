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
    public class Store
    {
        private int _id;
        private string? _name;
        //private Product _product1;
        //private Product _product2;
        //private Product _product3;
        private List<StoreItem> _items;

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
            var notfounditem =
                from e in _items
                where GetStoreItem() == null
                select e;

            foreach (var item in notfounditem)
            {
                AddStoreItem(prod, quantity);
            }

            var founditem =
                from e in _items
                where GetStoreItem() != null
                select e;
            
            foreach (var item in founditem)
            {
                item.SetQuantity(quantity);
                return item.GetQuantity();
            }




            //if (_product1 == null) 
            //{
            //    _product1 = prod;
            //}
            //else if (_product2 == null) 
            //{
            //    _product2 = prod;
            //}
            //else if (_product3 == null)
            //{
            //    _product3 = prod;
            //}
        }

        public void RemoveStoreItem(int productNum)
        {
            if (productNum == 1)
            {
                _product1 = null;
            }
            else if (productNum == 2) 
            {
                _product2 = null;
            }
            else if (productNum == 3)
            {
                _product3 = null;
            }
        }

        public List<StoreItem> GetStoreItem()
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
            else
            {
                return null;
            }

        }


    }
}
