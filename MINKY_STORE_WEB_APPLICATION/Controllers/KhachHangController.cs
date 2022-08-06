using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;
using System;
using System.Linq;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class KhachHangController : Controller
    {
        private IKhachHangService _iKhachHangService;
        public KhachHangController()
        {
            _iKhachHangService = new KhachHangService();
        }

        public IActionResult Index()
        {
            return View(_iKhachHangService.GetAll());
        }

        [Route("/khachhang/create")]
        public IActionResult Add(KhachHang obj)
        {
            _iKhachHangService.Add(obj);
            return RedirectToAction("Index", "KhachHang");
        }

        [Route("/khachhang/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _iKhachHangService.Remove(_iKhachHangService.GetById(id));
            return RedirectToAction("Index", "KhachHang");
        }

        [Route("/khachhang/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iKhachHangService.GetById(id));
        }

        [Route("/khachhang/update")]
        public IActionResult Update(KhachHang cv)
        {
            _iKhachHangService.Update(cv);
            return RedirectToAction("Index", "KhachHang");
        }
    }
}
