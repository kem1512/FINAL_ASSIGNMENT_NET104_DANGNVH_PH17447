using MinkyShop.Data.DomainClass;
using MinkyShop.Data.IRepositories;
using MinkyShop.Data.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System;
using System.Linq;
using System.Collections.Generic;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class ChucVuService : IChucVuService
    {
        private IChucVuRepository _iChucVuRepository;
        public ChucVuService(ApplicationDbContext context)
        {
            _iChucVuRepository = new ChucVuRepository(context);
        }

        public bool Add(ChucVu obj)
        {
            return _iChucVuRepository.Add(obj);
        }

        public List<ChucVu> GetAll()
        {
            return _iChucVuRepository.GetAll();
        }

        public ChucVu GetById(Guid id)
        {
            return _iChucVuRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Remove(ChucVu obj)
        {
            return _iChucVuRepository.Remove(obj);
        }

        public bool Update(ChucVu obj)
        {
            return _iChucVuRepository.Update(obj);
        }
    }
}
