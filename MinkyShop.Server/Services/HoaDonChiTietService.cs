using MinkyShop.Data.DomainClass;
using MinkyShop.Data.IRepositories;
using MinkyShop.Data.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private IHoaDonChiTietRepository _iHoaDonChiTietRepository;

        public HoaDonChiTietService(ApplicationDbContext context)
        {
            _iHoaDonChiTietRepository = new HoaDonChiTietRepository(context);
        }

        public bool Add(HoaDonChiTiet obj)
        {
            return _iHoaDonChiTietRepository.Add(obj);
        }

        public List<HoaDonChiTiet> GetAll()
        {
            return _iHoaDonChiTietRepository.GetAll();
        }

        public bool Remove(HoaDonChiTiet obj)
        {
            return _iHoaDonChiTietRepository.Remove(obj);
        }

        public bool Update(HoaDonChiTiet obj)
        {
            return _iHoaDonChiTietRepository.Update(obj);
        }
    }
}
