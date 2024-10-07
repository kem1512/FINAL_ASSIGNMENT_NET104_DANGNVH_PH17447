using System;
using MinkyShop.Data.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class SanPhamController : Controller
    {
        private ISanPhamService _iSanPhamService;

        public SanPhamController(ApplicationDbContext context)
        {
            _iSanPhamService = new SanPhamService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View(_iSanPhamService.GetAll());
        }

        [Route("/sanpham/create")]
        public IActionResult Add(SanPham obj)
        {
            TempData["Message"] = _iSanPhamService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "SanPham");
        }

        [Route("/sanpham/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            TempData["Message"] = _iSanPhamService.Remove(_iSanPhamService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "SanPham");
        }

        [Route("/sanpham/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iSanPhamService.GetById(id));
        }

        [Route("/sanpham/update")]
        public IActionResult Update(SanPham obj)
        {
            TempData["Message"] = _iSanPhamService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "SanPham");
        }
    }
}
