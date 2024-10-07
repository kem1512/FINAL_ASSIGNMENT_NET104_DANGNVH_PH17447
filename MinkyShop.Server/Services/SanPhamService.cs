using MinkyShop.Data.DomainClass;
using MinkyShop.Data.IRepositories;
using MinkyShop.Data.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class SanPhamService : ISanPhamService
    {
        private ISanPhamRepository _iSanPhamRepository;

        public SanPhamService(ApplicationDbContext context)
        {
            _iSanPhamRepository = new SanPhamRepository(context);
        }

        public bool Add(SanPham obj)
        {
            return _iSanPhamRepository.Add(obj);
        }

        public List<SanPham> GetAll()
        {
            return _iSanPhamRepository.GetAll();
        }

        public SanPham GetById(Guid id)
        {
            return _iSanPhamRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Remove(SanPham obj)
        {
            return _iSanPhamRepository.Remove(obj);
        }

        public bool Update(SanPham obj)
        {
            return _iSanPhamRepository.Update(obj);
        }
    }
}
