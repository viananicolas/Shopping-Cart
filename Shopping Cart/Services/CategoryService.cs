using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Shopping_Cart.AccessLayer;
using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public class CategoryService:IDisposable
    {
        private readonly ShoppingCartContext _db = new ShoppingCartContext();

        public List<Category> Get()
        {
            return _db.Categories.OrderBy(c => c.Name).ToList();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}