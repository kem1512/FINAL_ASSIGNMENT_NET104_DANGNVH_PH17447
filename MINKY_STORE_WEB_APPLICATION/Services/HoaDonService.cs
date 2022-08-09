using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using System.Linq;
using MINKY_STORE_WEB_APPLICATION.Models;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class HoaDonService : IHoaDonService
    {
        private IHoaDonRepository _iHoaDonRepository;
        private IHoaDonChiTietRepository _iHoaDonChiTietRepository;

        public HoaDonService()
        {
            _iHoaDonRepository = new HoaDonRepository();
            _iHoaDonChiTietRepository = new HoaDonChiTietRepository();
        }

        public bool Add(HoaDon obj)
        {
            return _iHoaDonRepository.Add(obj);
        }

        public List<HoaDon> GetAll()
        {
            return _iHoaDonRepository.GetAll();
        }

        public List<HoaDonViewModel> GetHoaDonViewModel()
        {
            var hoaDonViewModel = from a in _iHoaDonRepository.GetAll()
                join b in _iHoaDonChiTietRepository.GetAll() on a.Id equals b.IdHoaDon
                select new HoaDonViewModel() { HoaDon = a, HoaDonChiTiet = b };
            return hoaDonViewModel.ToList();
        }

        public bool Remove(HoaDon obj)
        {
            return _iHoaDonRepository.Remove(obj);
        }

        public bool Update(HoaDon obj)
        {
            return _iHoaDonRepository.Update(obj);
        }
    }
}
