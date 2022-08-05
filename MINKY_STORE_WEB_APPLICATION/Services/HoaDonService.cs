using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System.Collections.Generic;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class HoaDonService : IHoaDonService
    {
        private IHoaDonRepository _iHoaDonRepository;

        public HoaDonService()
        {
            _iHoaDonRepository = new HoaDonRepository();
        }

        public bool Add(HoaDon obj)
        {
            return _iHoaDonRepository.Add(obj);
        }

        public List<HoaDon> GetAll()
        {
            return _iHoaDonRepository.GetAll();
        }

        public bool Remove(HoaDon obj)
        {
            return _iHoaDonRepository.Remove(obj);
        }

        public bool Update(HoaDon obj)
        {
            return _iHoaDonRepository.Update(obj);
        }
    }
}
