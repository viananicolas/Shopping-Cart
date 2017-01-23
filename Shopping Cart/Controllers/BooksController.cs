using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Shopping_Cart.Models;
using Shopping_Cart.Services;
using Shopping_Cart.ViewModels;

namespace Shopping_Cart.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookService _bookService = new BookService();
        private readonly MapperConfiguration _config;
        private readonly IMapper _mapper;

        public BooksController()
        {
            _config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<Book, BookViewModel>();
                cfg.CreateMap<Author, AuthorViewModel>();
            });
            _mapper = _config.CreateMapper();
        }

        [ChildActionOnly]
        public PartialViewResult Featured()
        {
            var books = _bookService.GetFeatured();
            return PartialView(_mapper.Map<List<Book>, List<BookViewModel>>(books));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bookService.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Index(Guid categoryid)
        {
            var books = _bookService.GetByCategoryId(categoryid);
            ViewBag.SelectedCategoryId = categoryid;
            return View(_mapper.Map<List<Book>, List<BookViewModel>>(books));
        }

        public ActionResult Details(Guid id)
        {
            var book = _bookService.GetById(id);
            return View(_mapper.Map<Book, BookViewModel>(book));
        }
    }
}