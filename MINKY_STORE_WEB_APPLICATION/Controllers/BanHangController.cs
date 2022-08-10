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

        [NonAction]
        private int IsExist(Guid id)
        {
            List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].SanPhamViewModel.ChiTietSp.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

        [Route("/banhang/addcart/{id}")]
        public IActionResult AddCart(Guid id)
        {
            if (HttpContext.Session.GetObjectFromJson<List<ItemViewModel>>("cart") == null)
            {
                List<ItemViewModel> cart = new List<ItemViewModel>();
                cart.Add(new ItemViewModel() { SanPhamViewModel = _iChiTietSpService.GetSanPhamViewModel().FirstOrDefault(c => c.ChiTietSp.Id == id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new ItemViewModel { SanPhamViewModel = _iChiTietSpService.GetSanPhamViewModel().FirstOrDefault(c => c.ChiTietSp.Id == id), Quantity = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Cart");
        }

        public IActionResult Cart()
        {
            List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                var total = cart.Sum(c => c.SanPhamViewModel.ChiTietSp.GiaBan * c.Quantity);
                return View(new Tuple<List<ItemViewModel>, decimal>(cart, total));
            }
            return RedirectToAction("Index");
        }

        [Route("/banhang/filer")]
        public IActionResult Filter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return View("Index", _iChiTietSpService.GetSanPhamViewModel());
            }
            return View("Index", _iChiTietSpService.GetSanPhamViewModel().Where(c => c.SanPham.Ten.ToUpper().Contains(name.ToUpper().Trim())).ToList());
        }


        [Route("/banhang/updatecart")]
        public IActionResult UpdateCart(ItemViewModel itemViewModel)
        {
            List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
            int index = IsExist(itemViewModel.SanPhamViewModel.ChiTietSp.Id);
            if (index != -1)
            {
                cart[index].Quantity = itemViewModel.Quantity;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Cart", "BanHang");
        }

        [Route("/banhang/removecart/{id}")]
        public IActionResult Remove(Guid id)
        {

            List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Cart");
        }
    }
}
