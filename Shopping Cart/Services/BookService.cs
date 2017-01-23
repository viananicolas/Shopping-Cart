using System;
using System.Collections.Generic;
using System.Linq;
using Shopping_Cart.AccessLayer;
using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    public class BookService:IDisposable
    {
        private readonly ShoppingCartContext _dbCartContext = new ShoppingCartContext();

        public List<Book> GetFeatured()
        {
            return _dbCartContext.Books.Include("Author").Where(b => b.Featured).ToList();
        }
        public void Dispose()
        {
            _dbCartContext.Dispose();
        }

        public List<Book> GetByCategoryId(Guid categoryid)
        {
            return _dbCartContext.Books.Include("Author").
                Where(b => b.CategoryId==categoryid).
                OrderByDescending(b=>b.Featured).
                ToList();
        }

        public Book GetById(Guid id)
        {
            var book = _dbCartContext.Books.
                Include("Author").FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new ObjectDisposedException($"Não foi possível encontrar o livro {id}");
            }
            return book;
        }
    }
}