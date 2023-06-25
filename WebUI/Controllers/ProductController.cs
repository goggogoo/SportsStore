using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IProductsRepository repository;
        public int PageSize = 4;
        public ProductController(IProductsRepository productsRepository)
        {
            this.repository = productsRepository;
        }
        public ViewResult List(string category,int page=1)
        {
            ProductsListViewModel model = new Models.ProductsListViewModel
            {
                Products = repository.Products.Where(p=>category==null||p.Category==category).OrderBy(p => p.ProductId).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = PageSize,
                    TotalItems = category==null?repository.Products.Count():repository.Products.Where(e=>e.Category==category).Count()
                },
                CurrentCategory=category
            };
            return View(model);
            //return View(repository.Products.OrderBy(p=>p.ProductId).Skip((page-1)*PageSize).Take(PageSize));
        }
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}