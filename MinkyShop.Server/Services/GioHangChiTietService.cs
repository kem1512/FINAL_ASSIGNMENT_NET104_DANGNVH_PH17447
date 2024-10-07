using MinkyShop.Data.DomainClass;
using MinkyShop.Data.IRepositories;
using MinkyShop.Data.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class GioHangChiTietService : IGioHangChiTietService
    {
        private IGioHangChiTietRepository _iGioHangChiTietRepository;

        public GioHangChiTietService(ApplicationDbContext context)
        {
            _iGioHangChiTietRepository = new GioHangChiTietRepository(context);
        }

        public bool Add(GioHangChiTiet obj)
        {
            return _iGioHangChiTietRepository.Add(obj);
        }

        public List<GioHangChiTiet> GetAll()
        {
            return _iGioHangChiTietRepository.GetAll();
        }

        public bool Remove(GioHangChiTiet obj)
        {
            return _iGioHangChiTietRepository.Remove(obj);
        }

        public bool Update(GioHangChiTiet obj)
        {
            return _iGioHangChiTietRepository.Update(obj);
        }
    }
}
