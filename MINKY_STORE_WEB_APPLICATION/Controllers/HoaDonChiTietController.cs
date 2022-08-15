using System;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class HoaDonChiTietController : Controller
    {
        private IChiTietSpService _iChiTietSpService;
        private IHoaDonService _iHoaDonService;
        private IHoaDonChiTietService _iHoaDonChiTietService;

        public HoaDonChiTietController(FinalAssignmentContext context)
        {
            _iChiTietSpService = new ChiTietSpService(context);
            _iHoaDonService = new HoaDonService(context);
            _iHoaDonChiTietService = new HoaDonChiTietService(context);
        }

        [Route("/hoadonchitiet/{id}")]
        public IActionResult Index(Guid id)
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            var tuple = new Tuple<List<HoaDonViewModel>, List<SanPhamViewModel>>(_iHoaDonService.GetHoaDonViewModel().Where(c => c.HoaDon.Id == id).ToList(), _iChiTietSpService.GetSanPhamViewModel());
            return View(tuple);
        }

        [Route("/hoadonchitiet/update")]
        public IActionResult Update(HoaDonChiTiet obj)
        {
            TempData["Message"] = _iHoaDonChiTietService.Update(obj) ? "Sửa thành công" : "Sửa thất bại";
            return View("Index",new Tuple<List<HoaDonViewModel>, List<SanPhamViewModel>>(
                _iHoaDonService.GetHoaDonViewModel().Where(c => c.HoaDon.Id == obj.HoaDon.Id).ToList(),
                _iChiTietSpService.GetSanPhamViewModel()));
        }

        [Route("/hoadonchitiet/add")]
        public IActionResult Add(HoaDonChiTiet obj)
        {

            obj.DonGia = _iChiTietSpService.GetById(obj.IdChiTietSp).GiaBan;
            TempData["Message"] = _iHoaDonChiTietService.Add(obj) ? "Thêm thành công" : "Thêm thất bại";
            return RedirectToAction("Index", "BanHang");
        }
    }
}
