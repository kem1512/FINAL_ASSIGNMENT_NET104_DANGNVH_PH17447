using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using MinkyShop.Data.DomainClass;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class NhanVienController : Controller
    {
        private INhanVienService _iNhanVienService;
        private IChucVuService _iChucVuService;
        private ICuaHangService _iCuaHangService;

        public NhanVienController(ApplicationDbContext context)
        {
            _iNhanVienService = new NhanVienService(context);
            _iChucVuService = new ChucVuService(context);
            _iCuaHangService = new CuaHangService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            var tupleModel = new Tuple<List<NhanVienViewModel>, List<ChucVu>, List<CuaHang>>(_iNhanVienService.GetNhanVienViewModel(), _iChucVuService.GetAll(), _iCuaHangService.GetAll()); 
            return View(tupleModel);
        }

        [Route("/nhanvien/create")]
        public IActionResult Add(NhanVien obj)
        {
            TempData["Message"] = _iNhanVienService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "NhanVien");
        }

        [Route("/nhanvien/remove/{id}")]
        public IActionResult Delete(Guid id)
        {
            TempData["Message"] = _iNhanVienService.Remove(_iNhanVienService.GetById(id)) ? "Xóa thành công" : "Xóa thất bại";
            return RedirectToAction("Index", "NhanVien");
        }

        [Route("/nhanvien/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            ViewBag.CuaHang = _iCuaHangService.GetAll();
            ViewBag.ChucVu = _iChucVuService.GetAll();
            ViewBag.NhanVien = _iNhanVienService.GetAll();
            return View(_iNhanVienService.GetById(id));
        }

        [HttpPost]
        [Route("/nhanvien/update")]
        public IActionResult Update(NhanVien obj)
        {
            TempData["Message"] = _iNhanVienService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return RedirectToAction("Index", "NhanVien");
        }
    }
}
