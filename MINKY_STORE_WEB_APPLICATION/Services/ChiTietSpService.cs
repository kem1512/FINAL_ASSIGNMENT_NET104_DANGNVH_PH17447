using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.FlowAnalysis;
using MINKY_STORE_WEB_APPLICATION.Models;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class ChiTietSpService : IChiTietSpService
    {
        private IChiTietSpRepository _iChiTietSpRepository;
        private ISanPhamRepository _iSanPhamSpRepository;
        private INsxRepository _iNsxRepository;
        private IDongSpRepository _iDongSpRepository;
        private IMauSacRepository _iMauSacRepository;

        public ChiTietSpService()
        {
            _iMauSacRepository = new MauSacRepository();
            _iSanPhamSpRepository = new SanPhamRepository();
            _iNsxRepository = new NsxRepository();
            _iDongSpRepository = new DongSpRepository();
            _iChiTietSpRepository = new ChiTietSpRepository();
        }

        public int CurrentPage { get; set; }

        public bool Add(ChiTietSp obj)
        {
            return _iChiTietSpRepository.Add(obj);
        }

        public List<ChiTietSp> GetAll()
        {
            return _iChiTietSpRepository.GetAll();
        }

        public bool Remove(ChiTietSp obj)
        {
            return _iChiTietSpRepository.Remove(obj);
        }

        public bool Update(ChiTietSp obj)
        {
            return _iChiTietSpRepository.Update(obj);
        }

        public List<SanPhamViewModel> GetSanPhamViewModel()
        {
            #region Joint Linq

            // var listSanPhamViewModel = from ctsp in _iChiTietSpRepository.GetAll()
            //     join sp in _iSanPhamSpRepository.GetAll() on ctsp.IdSp equals sp.Id
            //     join nsx in _iNsxRepository.GetAll() on ctsp.IdNsx equals nsx.Id
            //     join dsp in _iDongSpRepository.GetAll() on ctsp.IdDongSp equals dsp.Id
            //     join ms in _iMauSacRepository.GetAll() on ctsp.IdMauSac equals ms.Id
            //     select new SanPhamViewModel() { ChiTietSp = ctsp, SanPham = sp, Nsx = nsx, DongSp = dsp, MauSac = ms 

            #endregion};

            #region Join Lambda

            var listSanPhamViewModel = _iChiTietSpRepository.GetAll()
                .Join(_iSanPhamSpRepository.GetAll(), ctsp => ctsp.IdSp, sp => sp.Id, (ctsp, sp) => new {ctsp, sp})
                .Join(_iNsxRepository.GetAll(), c => c.ctsp.IdNsx, nsx => nsx.Id, (c, nsx) => new {c, nsx})
                .Join(_iDongSpRepository.GetAll(), c => c.c.ctsp.IdDongSp, dsp => dsp.Id, (c, dsp) => new {c, dsp})
                .Join(_iMauSacRepository.GetAll(), c => c.c.c.ctsp.IdMauSac, ms => ms.Id, (c, ms) => new {c, ms})
                .Select(c => new SanPhamViewModel() { ChiTietSp = c.c.c.c.ctsp, SanPham = c.c.c.c.sp, Nsx = c.c.c.nsx, DongSp = c.c.dsp, MauSac = c.ms });

            #endregion
            return listSanPhamViewModel.ToList();
        }

        public ChiTietSp GetById(Guid id)
        {
            return _iChiTietSpRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool AddSanPhamViewModel(SanPhamViewModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
