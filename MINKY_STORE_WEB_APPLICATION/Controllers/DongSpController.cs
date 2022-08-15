using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class DongSpController : Controller
    {
        private IDongSpService _iDongSpService;

        public DongSpController(FinalAssignmentContext context)
        {
            _iDongSpService = new DongSpService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View(_iDongSpService.GetAll());
        }

        [Route("/dongsp/create")]
        public IActionResult Add(DongSp obj)
        {
            TempData["Message"] = _iDongSpService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "DongSp");
        }

        [Route("/dongsp/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            TempData["Message"] = _iDongSpService.Remove(_iDongSpService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "DongSp");
        }

        [Route("/dongsp/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iDongSpService.GetById(id));
        }

        [Route("/dongsp/update")]
        public IActionResult Update(DongSp obj)
        {
            TempData["Message"] = _iDongSpService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "DongSp");
        }
    }
}
