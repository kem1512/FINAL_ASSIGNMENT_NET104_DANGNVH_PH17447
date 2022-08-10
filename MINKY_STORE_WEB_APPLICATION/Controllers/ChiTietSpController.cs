using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class ChiTietSpController : Controller
    {
        private IChiTietSpService _iChiTietSpService;
        private ISanPhamService _iSanPhamService;
        private IMauSacService _iMauSacService;
        private IDongSpService _iDongSpService;
        private INsxService _iNsxService;

        public ChiTietSpController()
        {
            _iChiTietSpService = new ChiTietSpService();
            _iSanPhamService = new SanPhamService();
            _iMauSacService = new MauSacService();
            _iDongSpService = new DongSpService();
            _iNsxService = new NsxService();
        }

        public IActionResult Index()
        {
            var tupleModel = new Tuple<List<SanPhamViewModel>, List<SanPham>, List<MauSac>, List<DongSp>, List<Nsx>>(_iChiTietSpService.GetSanPhamViewModel(), _iSanPhamService.GetAll(), _iMauSacService.GetAll(), _iDongSpService.GetAll(), _iNsxService.GetAll());
            return View(tupleModel);
        }

        [Route("/chitietsp/create")]
        public IActionResult Add(ChiTietSp ctsp)
        {
            foreach (var x in _iChiTietSpService.GetAll())
            {
                if (ctsp.IdDongSp == x.IdDongSp && ctsp.IdMauSac == x.IdMauSac &&
                    ctsp.IdSp == x.IdSp && ctsp.IdNsx == x.IdNsx)
                {
                    return Content("Đã tồn tại!");
                }
            }
            _iChiTietSpService.Add(ctsp);
            return RedirectToAction("Index", "ChiTietSp");
        }

        [Route("/chitietsp/remove/{id}")]
        public IActionResult Delete(Guid id)
        {
            _iChiTietSpService.Remove(_iChiTietSpService.GetById(id));
            return RedirectToAction("Index", "ChiTietSp");
        }

        [Route("/chitietsp/detail/{id}")]
        public IActionResult Update(Guid id)
        {
            var tupleModel = new Tuple<ChiTietSp, List<SanPham>, List<MauSac>, List<DongSp>, List<Nsx>>(_iChiTietSpService.GetById(id), _iSanPhamService.GetAll(), _iMauSacService.GetAll(), _iDongSpService.GetAll(), _iNsxService.GetAll());
            return View(tupleModel);
        }

        [Route("/chitietsp/update")]
        public IActionResult Update(ChiTietSp cv)
        {
            _iChiTietSpService.Update(cv);
            return RedirectToAction("Index", "ChiTietSp");
        }
    }
}
