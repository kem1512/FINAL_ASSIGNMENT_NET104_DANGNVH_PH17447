using System;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using Microsoft.AspNetCore.Http;
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
        private INhanVienService _iNhanVienService;
        private IKhachHangService _iKhachHangService;
        public HoaDonController(FinalAssignmentContext context)
        {
            _ihoaDonService = new HoaDonService(context);
            _ihoaDonChiTietService = new HoaDonChiTietService(context);
            _iKhachHangService = new KhachHangService(context);
            _iNhanVienService = new NhanVienService(context);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View(_ihoaDonService.GetHoaDonViewModel());
        }

        [Route("/hoadon/status={status}")]
        public IActionResult Index(int status)
        {
            return View(_ihoaDonService.GetHoaDonViewModel().Where(c => c.HoaDon.TinhTrang == status).ToList());
        }

        [Route("/hoadon/add")]
        public IActionResult Add(HoaDon obj)
        {
            if (HttpContext.Session.GetString("cart") != null)
            {
                List<ItemViewModel> cart = SessionHelper.GetObjectFromJson<List<ItemViewModel>>(HttpContext.Session, "cart");
                obj.NgayTao = DateTime.Now;
                obj.IdKh = _iKhachHangService.GetAll()[0].Id;
                obj.IdNv = _iNhanVienService.GetAll()[0].Id;
                TempData["Message"] = _ihoaDonService.Add(obj) ? "Thêm hóa đơn thành công" : "Thêm hóa đơn thất bại";
                foreach (var x in cart)
                {
                    if (!_ihoaDonChiTietService.Add(new HoaDonChiTiet()
                        {
                            IdHoaDon = obj.Id, IdChiTietSp = x.SanPhamViewModel.ChiTietSp.Id,
                            DonGia = x.SanPhamViewModel.ChiTietSp.GiaBan, SoLuong = x.Quantity
                        }))
                    {
                        TempData["Message"] = "Thêm chi tiết hóa đơn thất bại!";
                    };
                }
                HttpContext.Session.Remove("cart");
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
               TempData["Message"] = "Thanh toán thành công";
           }
           else
           {
               TempData["Message"] = "Thanh toán thất bại";
           }
           return RedirectToAction("Index");
        }
    }
}
