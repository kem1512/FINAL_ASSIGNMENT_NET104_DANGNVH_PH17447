using System;
using System.Diagnostics;
using MinkyShop.Data.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class CuaHangController : Controller
    {
        private readonly ICuaHangService _iCuaHangService;

        public CuaHangController(ApplicationDbContext context)
        {
            _iCuaHangService = new CuaHangService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View(_iCuaHangService.GetAll());
        }

        [Route("/cuahang/create")]
        public IActionResult Add(CuaHang obj)
        {
            TempData["Message"] = _iCuaHangService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "CuaHang");
        }

        [Route("/cuahang/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            TempData["Message"] = _iCuaHangService.Remove(_iCuaHangService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "CuaHang");
        }

        [Route("/cuahang/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iCuaHangService.GetById(id));
        }

        [HttpPost]
        [Route("/cuahang/update")]
        public IActionResult Update(CuaHang obj)
        {
            TempData["Message"] = _iCuaHangService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "CuaHang");
        }
    }
}
