using System;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class CuaHangService : ICuaHangService
    {
        private ICuaHangRepository _iCuaHangRepository;

        public CuaHangService(FinalAssignmentContext context)
        {
            _iCuaHangRepository = new CuaHangRepository(context);
        }

        public bool Add(CuaHang obj)
        {
            return _iCuaHangRepository.Add(obj);
        }

        public List<CuaHang> GetAll()
        {
            return _iCuaHangRepository.GetAll();
        }

        public CuaHang GetById(Guid id)
        {
            return _iCuaHangRepository.GetAll().FirstOrDefault(c => c.Id == id);
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
