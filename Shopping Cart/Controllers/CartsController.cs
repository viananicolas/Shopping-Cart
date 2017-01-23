using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Shopping_Cart.Models;
using Shopping_Cart.Services;
using Shopping_Cart.ViewModels;

namespace Shopping_Cart.Controllers
{
    public class CartsController : Controller
    {
        private readonly CartService _cartService = new CartService();
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;
        public CartsController()
        {
            _config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Cart, CartViewModel>();
                cfg.CreateMap<CartItem, CartItemViewModel>();
                cfg.CreateMap<Book,BookViewModel>();
                cfg.CreateMap<Author, AuthorViewModel>();
                cfg.CreateMap<Category, CategoryViewModel>();
            });
            _mapper = _config.CreateMapper();
        }
        public ActionResult Index()
        {
            var cart = _cartService.GetBySessionId(HttpContext.Session?.SessionID);
            return View(_mapper.Map<Cart, CartViewModel>(cart));
        }
        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            var cart = _cartService.GetBySessionId(HttpContext.Session?.SessionID);
            return PartialView(_mapper.Map<Cart, CartViewModel>(cart));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cartService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}