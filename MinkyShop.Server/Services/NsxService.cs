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
    public class NsxService : INsxService
    {
        private INsxRepository _iNsxRepository;

        public NsxService(ApplicationDbContext context)
        {
            _iNsxRepository = new NsxRepository(context);
        }

        public bool Add(Nsx obj)
        {
            return _iNsxRepository.Add(obj);
        }

        public List<Nsx> GetAll()
        {
            return _iNsxRepository.GetAll();
        }

        public Nsx GetById(Guid id)
        {
            return _iNsxRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Remove(Nsx obj)
        {
            return _iNsxRepository.Remove(obj);
        }

        public bool Update(Nsx obj)
        {
            return _iNsxRepository.Update(obj);
        }
    }
}
