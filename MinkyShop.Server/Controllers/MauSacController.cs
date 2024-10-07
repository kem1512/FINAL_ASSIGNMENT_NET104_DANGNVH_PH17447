using System;
using System.Collections.Generic;
using MinkyShop.Data.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class MauSacController : Controller
    {
        private IMauSacService _iMauSacService;

        public MauSacController(ApplicationDbContext context)
        {
            _iMauSacService = new MauSacService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View(_iMauSacService.GetAll());
        }

        [Route("/mausac/create")]
        public IActionResult Add(MauSac obj)
        {
            TempData["Message"] = _iMauSacService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "MauSac");
        }

        [Route("/mausac/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            TempData["Message"] = _iMauSacService.Remove(_iMauSacService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "MauSac");
        }

        [Route("/mausac/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iMauSacService.GetById(id));
        }

        [Route("/mausac/update")]
        public IActionResult Update(MauSac obj)
        {
            TempData["Message"] = _iMauSacService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "MauSac");
        }
    }
}
