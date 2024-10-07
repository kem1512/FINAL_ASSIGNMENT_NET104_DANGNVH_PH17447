using System;
using MinkyShop.Data.DomainClass;
using MinkyShop.Data.IRepositories;
using MinkyShop.Data.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using System.Linq;
using MinkyShop.Infrastructure.Data;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class DongSpService : IDongSpService
    {
        private IDongSpRepository _iDongSpRepository;

        public DongSpService(ApplicationDbContext context)
        {
            _iDongSpRepository = new DongSpRepository(context);
        }

        public bool Add(DongSp obj)
        {
            return _iDongSpRepository.Add(obj);
        }

        public List<DongSp> GetAll()
        {
            return _iDongSpRepository.GetAll();
        }

        public DongSp GetById(Guid id)
        {
            return _iDongSpRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Remove(DongSp obj)
        {
            return _iDongSpRepository.Remove(obj);
        }

        public bool Update(DongSp obj)
        {
            return _iDongSpRepository.Update(obj);
        }
    }
}
