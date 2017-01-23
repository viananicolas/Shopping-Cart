using System.Web.Http;
using AutoMapper;
using Shopping_Cart.Models;
using Shopping_Cart.Services;
using Shopping_Cart.ViewModels;

namespace Shopping_Cart.Controllers.Api
{
    public class CartItemsController : ApiController
    {
        private readonly CartItemService _cartItemService = new CartItemService();
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;

        public CartItemsController()
        {
            _config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartItem, CartItemViewModel>();
                cfg.CreateMap<Book, BookViewModel>();
                cfg.CreateMap<Author, AuthorViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();

                cfg.CreateMap<CartViewModel, Cart>();
                cfg.CreateMap<CartItemViewModel, CartItem>();
                cfg.CreateMap<BookViewModel, Book>();
                cfg.CreateMap<AuthorViewModel, Author>();
                cfg.CreateMap<CategoryViewModel, Category>();
            });
            _mapper = _config.CreateMapper();
        }

        public CartItemViewModel Post(CartItemViewModel cartItem)
        {
            var newCartItem =_cartItemService.AddToCart(
                    _mapper.Map<CartItemViewModel, CartItem>(
                        cartItem));
            return _mapper.Map<CartItem, CartItemViewModel>(newCartItem);
        }
        public CartItemViewModel Put(CartItemViewModel cartItem)
        {
            _cartItemService.UpdateCartItem(_mapper.Map<CartItemViewModel, CartItem>(
                cartItem));
            return cartItem;
        }
        public CartItemViewModel Delete(CartItemViewModel cartItem)
        {
            _cartItemService.DeleteCartItem(_mapper.Map<CartItemViewModel, CartItem>(
                cartItem));
            return cartItem;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartItemService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
