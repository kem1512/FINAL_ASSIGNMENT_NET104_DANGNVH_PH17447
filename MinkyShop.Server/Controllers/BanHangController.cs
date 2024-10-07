using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;
using MINKY_STORE_WEB_APPLICATION.Utilities;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class BanHangController : Controller
    {
        private IChiTietSpService _iChiTietSpService;
        public BanHangController(ApplicationDbContext context)
        {
            _iChiTietSpService = new ChiTietSpService(context);
        }

        private List<SanPhamViewModel> ProductPaging(int currentPage)
        {
            int maxRows = 4;
            var productPaging = _iChiTietSpService.GetSanPhamViewModel().Skip((currentPage - 1) * maxRows).Take(maxRows).ToList();
            ViewBag.PageCount = (int)Math.Ceiling(_iChiTietSpService.GetSanPhamViewModel().Count / (decimal) maxRows);
            ViewBag.CurrentPageIndex = _iChiTietSpService.CurrentPage = currentPage;
            return productPaging;
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View(ProductPaging(1));
        }

        [Route("/banhang/page={currentPage}")]
        public IActionResult Index(int currentPage)
        {
            return View(ProductPaging(currentPage));
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
            TempData["Message"] = "Thêm thành công";
            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                var total = cart.Sum(c => c.SanPhamViewModel.ChiTietSp.GiaBan * c.Quantity);
                return View(new Tuple<List<ItemViewModel>, decimal>(cart, total));
            }
            return RedirectToAction("Index");
        }

        [Route("/banhang/filter")]
        public IActionResult Filter(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return View("Index", _iChiTietSpService.GetSanPhamViewModel());
            }
            return View("Index", _iChiTietSpService.GetSanPhamViewModel().Where(c => c.SanPham.Ten.ToUpper().Contains(name.ToUpper().Trim())).ToList());
        }


        [Route("/banhang/updatecart")]
        public IActionResult UpdateCart(ItemViewModel obj)
        {
            List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
            int index = IsExist(obj.SanPhamViewModel.ChiTietSp.Id);
            if (index != -1)
            {
                cart[index].Quantity = obj.Quantity;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                TempData["Message"] = "Sửa thành công";
            }
            else
            {
                TempData["Message"] = "Sửa thất bại";
            }
            return RedirectToAction("Cart", "BanHang");
        }

        [Route("/banhang/removecart/{id}")]
        public IActionResult RemoveCart(Guid id)
        {

            List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            if (index != -1)
            {
                cart.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                TempData["Message"] = "Xóa thành công";
            }
            else
            {
                TempData["Message"] = "Xóa thất bại";
            }
            return RedirectToAction("Cart");
        }
    }
}
