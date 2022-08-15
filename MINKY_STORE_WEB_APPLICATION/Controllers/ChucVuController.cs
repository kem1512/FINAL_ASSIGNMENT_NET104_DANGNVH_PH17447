using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class ChucVuController : Controller
    {
        private IChucVuService _iChucVuService;
        public ChucVuController(FinalAssignmentContext context)
        {
            _iChucVuService = new ChucVuService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            ViewBag.Result = _iChucVuService.GetAll();
            return View();
        }

        [HttpPost]
        [Route("/chucvu/create")]
        public IActionResult Add(ChucVu obj)
        {
            TempData["Message"] = _iChucVuService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "ChucVu");
        }

        [Route("/chucvu/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            TempData["Message"] = _iChucVuService.Remove(_iChucVuService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "ChucVu");
        }

        [Route("/chucvu/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iChucVuService.GetById(id));
        }

        [HttpPost]
        [Route("/chucvu/update")]
        public IActionResult Update(ChucVu obj)
        {
            TempData["Message"] = _iChucVuService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "ChucVu");
        }
    }
}
