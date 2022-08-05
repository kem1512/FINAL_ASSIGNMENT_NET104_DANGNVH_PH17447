using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using MINKY_STORE_WEB_APPLICATION.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class NhanVienService : INhanVienService
    {
        private INhanVienRepository _iNhanVienRepository;
        private IChucVuRepository _iChucVuRepository;
        private ICuaHangRepository _iCuaHangRepository;

        public NhanVienService()
        {
            _iNhanVienRepository = new NhanVienRepository();
            _iChucVuRepository = new ChucVuRepository();
            _iCuaHangRepository = new CuaHangRepository();
        }

        public bool Add(NhanVien obj)
        {
            return _iNhanVienRepository.Add(obj);
        }

        public List<NhanVien> GetAll()
        {
            return _iNhanVienRepository.GetAll();
        }

        public NhanVien GetById(Guid id)
        {
            return _iNhanVienRepository.GetAll().FirstOrDefault(x => x.Id == id);
       }

        public List<NhanVienViewModel> GetNhanVienViewModel()
        {
            var listNhanVienViewModel = from nv in _iNhanVienRepository.GetAll()
                join cv in _iChucVuRepository.GetAll() on nv.IdCv equals cv.Id
                join ch in _iCuaHangRepository.GetAll() on nv.IdCh equals ch.Id
                select new NhanVienViewModel() {NhanVien = nv, ChucVu = cv, CuaHang = ch};
            return listNhanVienViewModel.ToList();
        }

        public bool Remove(NhanVien obj)
        {
            return _iNhanVienRepository.Remove(obj);
        }

        public bool Update(NhanVien obj)
        {
            return _iNhanVienRepository.Update(obj);
        }
    }
}
