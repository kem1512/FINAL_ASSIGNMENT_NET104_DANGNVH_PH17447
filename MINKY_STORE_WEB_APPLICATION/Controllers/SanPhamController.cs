using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Services;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class SanPhamController : Controller
    {
        private ISanPhamService _iSanPhamService;

        public SanPhamController()
        {
            _iSanPhamService = new SanPhamService();
        }

        public IActionResult Index()
        {
            return View(_iSanPhamService.GetAll());
        }

        [Route("/sanpham/create")]
        public IActionResult Add(SanPham obj)
        {
            _iSanPhamService.Add(obj);
            return RedirectToAction("Index", "SanPham");
        }

        [Route("/sanpham/remove/{id}")]
        public IActionResult Remove(Guid id)
        {
            _iSanPhamService.Remove(_iSanPhamService.GetById(id));
            return RedirectToAction("Index", "SanPham");
        }

        [Route("/sanpham/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            return View(_iSanPhamService.GetById(id));
        }

        [Route("/sanpham/update")]
        public IActionResult Update(SanPham cv)
        {
            _iSanPhamService.Update(cv);
            return RedirectToAction("Index", "SanPham");
        }
    }
}
