using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class GioHangService : IGioHangService
    {
        private IGioHangRepository _iGioHangRepository;

        public GioHangService(FinalAssignmentContext context)
        {
            _iGioHangRepository = new GioHangRepository(context);
        }

        public bool Add(GioHang obj)
        {
            return _iGioHangRepository.Add(obj);
        }

        public List<GioHang> GetAll()
        {
            return _iGioHangRepository.GetAll();
        }

        public bool Remove(GioHang obj)
        {
            return _iGioHangRepository.Remove(obj);
        }

        public bool Update(GioHang obj)
        {
            return _iGioHangRepository.Update(obj);
        }
    }
}
