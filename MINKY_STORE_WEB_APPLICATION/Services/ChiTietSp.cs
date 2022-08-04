using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class ChiTietSpService : IChiTietSpService
    {
        private IChiTietSpRepository _iChiTietSpRepository;

        public ChiTietSpService()
        {
            _iChiTietSpRepository = new ChiTietSpRepository();
        }

        public bool Add(ChiTietSp obj)
        {
            return _iChiTietSpRepository.Add(obj);
        }

        public List<ChiTietSp> GetAll()
        {
            return _iChiTietSpRepository.GetAll();
        }

        public bool Remove(ChiTietSp obj)
        {
            return _iChiTietSpRepository.Remove(obj);
        }

        public bool Update(ChiTietSp obj)
        {
            return _iChiTietSpRepository.Update(obj);
        }
    }
}
