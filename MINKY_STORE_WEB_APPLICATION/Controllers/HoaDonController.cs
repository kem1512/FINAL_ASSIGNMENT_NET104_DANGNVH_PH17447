using System;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;
using MINKY_STORE_WEB_APPLICATION.Utilities;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class HoaDonController : Controller
    {
        private IHoaDonService _ihoaDonService;
        private IHoaDonChiTietService _ihoaDonChiTietService;
        public HoaDonController()
        {
            _ihoaDonService = new HoaDonService();
            _ihoaDonChiTietService = new HoaDonChiTietService();
        }

        public IActionResult Index()
        {
            return View(_ihoaDonService.GetHoaDonViewModel());
        }

        [Route("/hoadon/filter/{status}")]
        public IActionResult Filter(int status)
        {
            return View("Index", _ihoaDonService.GetHoaDonViewModel().Where(c => c.HoaDon.TinhTrang == status).ToList());
        }

        [Route("/hoadon/add")]
        public IActionResult Add(HoaDon hoaDon)
        {
            List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
            hoaDon.NgayTao = DateTime.Now;
            _ihoaDonService.Add(hoaDon);
            foreach (var x in cart)
            {
                _ihoaDonChiTietService.Add(new HoaDonChiTiet(){ IdHoaDon = hoaDon.Id, IdChiTietSp = x.SanPhamViewModel.ChiTietSp.Id, DonGia = x.SanPhamViewModel.ChiTietSp.GiaBan, SoLuong = x.Quantity});
            }
            return RedirectToAction("Index", "BanHang");
        }

        [Route("/hoadon/thanhtoan/{id}")]
        public IActionResult CompleteOrder(Guid id)
        {
           var hoadon = _ihoaDonService.GetAll().FirstOrDefault(c => c.Id == id);
           if (hoadon != null)
           {
               hoadon.TinhTrang = 1;
               _ihoaDonService.Update(hoadon);
           }
           return RedirectToAction("Index");
        }
    }
}
