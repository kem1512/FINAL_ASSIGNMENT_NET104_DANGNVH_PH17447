using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;
using MINKY_STORE_WEB_APPLICATION.Utilities;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class BanHangController : Controller
    {
        private IChiTietSpService _iChiTietSpService;
        public BanHangController()
        {
            _iChiTietSpService = new ChiTietSpService();
        }

        public IActionResult Index()
        {
            return View(_iChiTietSpService.GetSanPhamViewModel());
        }

        [Route("/banhang/addcart/{id}")]
        public IActionResult AddCart(Guid id)
        {
            if (SessionHelper.GetObjectFromJson<Item>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item() { SanPhamViewModel = _iChiTietSpService.GetSanPhamViewModel().FirstOrDefault(c => c.ChiTietSp.Id == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            return View();
        }

        [Route("/banhang/view")]
        public IActionResult ViewCart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            return Conflict(cart);
        }
    }
}
