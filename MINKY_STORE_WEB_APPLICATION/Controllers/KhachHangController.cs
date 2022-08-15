using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;
using System;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class KhachHangController : Controller
    {
        private IKhachHangService _iKhachHangService;
        public KhachHangController(FinalAssignmentContext context)
        {
            _iKhachHangService = new KhachHangService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View(_iKhachHangService.GetAll());
        }

        [Route("/khachhang/create")]
        public IActionResult Add(KhachHang obj)
        {
            TempData["Message"] = _iKhachHangService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "KhachHang");
        }

        [Route("/khachhang/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            TempData["Message"] = _iKhachHangService.Remove(_iKhachHangService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "KhachHang");
        }

        [Route("/khachhang/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iKhachHangService.GetById(id));
        }

        [Route("/khachhang/update")]
        public IActionResult Update(KhachHang obj)
        {
            TempData["Message"] = _iKhachHangService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "KhachHang");
        }
    }
}
