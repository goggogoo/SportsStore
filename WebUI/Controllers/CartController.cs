﻿using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private IProductsRepository repository;
        private IOrderProcessor orderProcessor;
        public CartController(IProductsRepository repo,IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }
        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = cart, ReturnUrl = returnUrl });
        }
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart,ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0) { ModelState.AddModelError("", "Sorry,your cart is empty!"); }
            if (ModelState.IsValid) 
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productId,string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        //private Cart GetCart()
        //{
        //    Cart cart = (Cart)Session["Cart"];
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}