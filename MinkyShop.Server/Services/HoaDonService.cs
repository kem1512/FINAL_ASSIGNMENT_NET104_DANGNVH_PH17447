using MinkyShop.Data.DomainClass;
using MinkyShop.Data.IRepositories;
using MinkyShop.Data.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using System.Linq;
using MINKY_STORE_WEB_APPLICATION.Models;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class HoaDonService : IHoaDonService
    {
        private IHoaDonRepository _iHoaDonRepository;
        private IHoaDonChiTietRepository _iHoaDonChiTietRepository;

        public HoaDonService(ApplicationDbContext context)
        {
            _iHoaDonRepository = new HoaDonRepository(context);
            _iHoaDonChiTietRepository = new HoaDonChiTietRepository(context);
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
