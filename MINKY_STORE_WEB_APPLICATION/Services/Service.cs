using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class CuaHangService : ICuaHangService
    {
        private ICuaHangRepository _iCuaHangRepository;

        public CuaHangService()
        {
            _iCuaHangRepository = new CuaHangRepository();
        }

        public bool Add(CuaHang obj)
        {
            return _iCuaHangRepository.Add(obj);
        }

        public List<CuaHang> GetAll()
        {
            return _iCuaHangRepository.GetAll();
        }

        public bool Remove(CuaHang obj)
        {
            return _iCuaHangRepository.Remove(obj);
        }

        public bool Update(CuaHang obj)
        {
            return _iCuaHangRepository.Update(obj);
        }
    }
}
