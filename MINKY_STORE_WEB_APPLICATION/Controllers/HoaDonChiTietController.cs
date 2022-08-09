using System;
using System.Collections.Generic;
using System.Linq;
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

        public HoaDonChiTietController()
        {
            _iChiTietSpService = new ChiTietSpService();
            _iHoaDonService = new HoaDonService();
            _iHoaDonChiTietService = new HoaDonChiTietService();
        }

        [Route("/hoadonchitiet/{id}")]
        public IActionResult Index(Guid id)
        {
            var tuple = new Tuple<List<HoaDonViewModel>, List<SanPhamViewModel>>(_iHoaDonService.GetHoaDonViewModel().Where(c => c.HoaDon.Id == id).ToList(), _iChiTietSpService.GetSanPhamViewModel());
            return View(tuple);
        }

        [Route("/hoadonchitiet/update")]
        public IActionResult Update(HoaDonChiTiet hoaDonChiTiet)
        {
            _iHoaDonChiTietService.Update(hoaDonChiTiet);
            return RedirectToAction("Index", "BanHang");
        }

        [Route("/hoadonchitiet/add")]
        public IActionResult Add(HoaDonChiTiet hoaDonChiTiet)
        {
            hoaDonChiTiet.DonGia = _iChiTietSpService.GetById(hoaDonChiTiet.IdChiTietSp).GiaBan;
            _iHoaDonChiTietService.Add(hoaDonChiTiet);
            return RedirectToAction("Index", "BanHang");
        }

        // [Route("hoadon/thanhtoan/{id}")]
        // public IActionResult ThanhToan(Guid id)
        // {
        //     var result = _iHoaDonService.GetAll().FirstOrDefault(c => c.Id == id);
        //     result.TinhTrang = 1;
        //     _iHoaDonService.Update(result);
        //     return RedirectToAction("Index", "BanHang");
        // }
        //
        // [Route("hoadonchitiet/update/id={id},soluong={soluong}")]
        // public IActionResult Update(HoaDonChiTiet hoaDonChiTiet)
        // {
        //     _iHoaDonChiTietService.Update(hoaDonChiTiet);
        //     return View();
        // }
    }
}
