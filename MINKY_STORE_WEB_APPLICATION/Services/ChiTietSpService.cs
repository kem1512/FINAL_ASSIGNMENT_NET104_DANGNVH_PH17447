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
            var listSanPhamViewModel = from ctsp in _iChiTietSpRepository.GetAll()
                join sp in _iSanPhamSpRepository.GetAll() on ctsp.IdSp equals sp.Id
                join nsx in _iNsxRepository.GetAll() on ctsp.IdNsx equals nsx.Id
                join dsp in _iDongSpRepository.GetAll() on ctsp.IdDongSp equals dsp.Id
                join ms in _iMauSacRepository.GetAll() on ctsp.IdMauSac equals ms.Id
                select new SanPhamViewModel() { ChiTietSp = ctsp, SanPham = sp, Nsx = nsx, DongSp = dsp, MauSac = ms };
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
