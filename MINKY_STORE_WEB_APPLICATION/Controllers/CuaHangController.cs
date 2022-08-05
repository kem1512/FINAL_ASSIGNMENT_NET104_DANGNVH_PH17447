using System;
using System.Diagnostics;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class CuaHangController : Controller
    {
        private readonly ICuaHangService _iCuaHangService;

        public CuaHangController()
        {
            _iCuaHangService = new CuaHangService();
        }

        public IActionResult Index()
        {
            return View(_iCuaHangService.GetAll());
        }

        [Route("/cuahang/create")]
        public IActionResult Add(CuaHang obj)
        {
            _iCuaHangService.Add(obj);
            return RedirectToAction("Index", "CuaHang");
        }

        [Route("/cuahang/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _iCuaHangService.Remove(_iCuaHangService.GetById(id));
            return RedirectToAction("Index", "CuaHang");
        }

        [Route("/cuahang/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iCuaHangService.GetById(id));
        }

        [Route("/cuahang/update")]
        public IActionResult Update(CuaHang cv)
        {
            _iCuaHangService.Update(cv);
            return RedirectToAction("Index", "CuaHang");
        }
    }
}
