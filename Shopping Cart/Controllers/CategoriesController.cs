using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Shopping_Cart.Models;
using Shopping_Cart.Services;
using Shopping_Cart.ViewModels;

namespace Shopping_Cart.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService = new CategoryService();
        private readonly MapperConfiguration _config;
        public CategoriesController()
        {
            _config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Category, CategoryViewModel>();
            });
        }
        public PartialViewResult Menu(Guid selectedCategoryId)
        {
            var categories = _categoryService.Get();
            var mapper = _config.CreateMapper();
            ViewBag.SelectedCategoryId = selectedCategoryId;
            return PartialView(mapper.Map<List<Category>, List<CategoryViewModel>>(categories));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _categoryService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}