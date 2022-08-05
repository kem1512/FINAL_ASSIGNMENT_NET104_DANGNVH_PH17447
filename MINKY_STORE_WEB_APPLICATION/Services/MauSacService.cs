using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using System.Linq;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class MauSacService : IMauSacService
    {
        private IMauSacRepository _iMauSacRepository;

        public MauSacService()
        {
            _iMauSacRepository = new MauSacRepository();
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
