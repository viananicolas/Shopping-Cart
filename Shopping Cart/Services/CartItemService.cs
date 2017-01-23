using System;
using System.Data.Entity;
using System.Linq;
using Shopping_Cart.AccessLayer;
using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    internal class CartItemService:IDisposable
    {
        private ShoppingCartContext _dbShoppingCartContext = new ShoppingCartContext();

        public CartItem GetByCartIdAndBookId(Guid cartId, Guid bookId)
        {
            return _dbShoppingCartContext.CartItems.SingleOrDefault(ci => ci.CartId == cartId &&
                                                                          ci.BookId == bookId);
        }

        public CartItem AddToCart(CartItem cartItem)
        {
            var existingCartItem = GetByCartIdAndBookId(cartItem.CartId, cartItem.BookId);
            if (existingCartItem == null)
            {
                _dbShoppingCartContext.Entry(cartItem).State=EntityState.Added;
                existingCartItem = cartItem;
            }
            else
            {
                existingCartItem.Quantity += cartItem.Quantity;
            }
            _dbShoppingCartContext.SaveChanges();
            return existingCartItem;
        }
        public void Dispose()
        {
            _dbShoppingCartContext.Dispose();
        }

        public void UpdateCartItem(CartItem cartItem)
        {
            _dbShoppingCartContext.Entry(cartItem).State=EntityState.Modified;
            _dbShoppingCartContext.SaveChanges();
        }

        public void DeleteCartItem(CartItem cartItem)
        {
            _dbShoppingCartContext.Entry(cartItem).State = EntityState.Deleted;
            _dbShoppingCartContext.SaveChanges();
        }
    }
}