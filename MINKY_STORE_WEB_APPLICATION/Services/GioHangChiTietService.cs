using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class GioHangChiTietService : IGioHangChiTietService
    {
        private IGioHangChiTietRepository _iGioHangChiTietRepository;

        public GioHangChiTietService(FinalAssignmentContext context)
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
