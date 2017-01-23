using System;
using System.Collections.Generic;
using System.Linq;
using Shopping_Cart.AccessLayer;
using Shopping_Cart.Models;

namespace Shopping_Cart.Services
{
    internal class CartService:IDisposable
    {
        private readonly ShoppingCartContext _dbCartContext = new ShoppingCartContext();

        public Cart GetBySessionId(string sessionId)
        {
            var cart = _dbCartContext.Carts.
                Include("CartItems").
                SingleOrDefault(c => c.SessionId == sessionId);
            cart = CreateCartIfItDoesntExist(sessionId, cart);
            return cart;
        }

        private Cart CreateCartIfItDoesntExist(string sessionId, Cart cart)
        {
            if (cart == null)
            {
                cart = new Cart
                {
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };
                _dbCartContext.Carts.Add(cart);
                _dbCartContext.SaveChangesAsync();
            }
            return cart;
        }

        public void Dispose()
        {
            _dbCartContext.Dispose();
        }
    }
}