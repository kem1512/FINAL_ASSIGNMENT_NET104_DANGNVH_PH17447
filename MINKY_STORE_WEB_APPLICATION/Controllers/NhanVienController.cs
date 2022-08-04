﻿using Microsoft.AspNetCore.Mvc;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using MINKY_STORE_WEB_APPLICATION.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;

namespace MINKY_STORE_WEB_APPLICATION.Controllers
{
    public class NhanVienController : Controller
    {
        private INhanVienService _iNhanVienService;
        private IChucVuService _iChucVuService;
        private ICuaHangService _iCuaHangService;

        public NhanVienController()
        {
            _iNhanVienService = new NhanVienService();
            _iChucVuService = new ChucVuService();
            _iCuaHangService = new CuaHangService();
        }

        public IActionResult Index()
        {
            var tupleModel = new Tuple<List<ViewNhanVien>, List<ChucVu>, List<CuaHang>>(_iNhanVienService.GetViewNhanVien(), _iChucVuService.GetAll(), _iCuaHangService.GetAll()); 
            return View(tupleModel);
        }

        [Route("/nhanvien/create")]
        public IActionResult Add(NhanVien nv)
        {
            _iNhanVienService.Add(nv);
            return RedirectToAction("Index", "NhanVien");
        }

        [Route("/nhanvien/delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _iNhanVienService.Remove(_iNhanVienService.GetById(id));
            return RedirectToAction("Index", "NhanVien");
        }
    }
}