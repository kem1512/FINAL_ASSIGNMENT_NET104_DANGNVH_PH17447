using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class KhachHangService : IKhachHangService
    {
        private IKhachHangRepository _iKhachHangRepository;

        public KhachHangService()
        {
            _iKhachHangRepository = new KhachHangRepository();
        }

        public bool Add(KhachHang obj)
        {
            return _iKhachHangRepository.Add(obj);
        }

        public List<KhachHang> GetAll()
        {
            return _iKhachHangRepository.GetAll();
        }

        public bool Remove(KhachHang obj)
        {
            return _iKhachHangRepository.Remove(obj);
        }

        public bool Update(KhachHang obj)
        {
            return _iKhachHangRepository.Update(obj);
        }
    }
}
