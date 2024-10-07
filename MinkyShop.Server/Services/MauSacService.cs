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
    public class MauSacService : IMauSacService
    {
        private IMauSacRepository _iMauSacRepository;

        public MauSacService(ApplicationDbContext context)
        {
            _iMauSacRepository = new MauSacRepository(context);
        }

        public bool Add(MauSac obj)
        {
            return _iMauSacRepository.Add(obj);
        }

        public List<MauSac> GetAll()
        {
            return _iMauSacRepository.GetAll();
        }

        public bool Remove(MauSac obj)
        {
            return _iMauSacRepository.Remove(obj);
        }

        public bool Update(MauSac obj)
        {
            return _iMauSacRepository.Update(obj);
        }

        public MauSac GetById(Guid id)
        {
            return _iMauSacRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }
    }
}
