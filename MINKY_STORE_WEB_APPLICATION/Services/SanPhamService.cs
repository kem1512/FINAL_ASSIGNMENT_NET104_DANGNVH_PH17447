using EF_CODE_FIRST_FINAL_ASSIGNMENT.DomainClass;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.IRepositories;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Repositories;
using MINKY_STORE_WEB_APPLICATION.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using EF_CODE_FIRST_FINAL_ASSIGNMENT.Context;

namespace MINKY_STORE_WEB_APPLICATION.Services
{
    public class SanPhamService : ISanPhamService
    {
        private ISanPhamRepository _iSanPhamRepository;

        public SanPhamService(FinalAssignmentContext context)
        {
            _iSanPhamRepository = new SanPhamRepository(context);
        }

        public bool Add(SanPham obj)
        {
            return _iSanPhamRepository.Add(obj);
        }

        public List<SanPham> GetAll()
        {
            return _iSanPhamRepository.GetAll();
        }

        public SanPham GetById(Guid id)
        {
            return _iSanPhamRepository.GetAll().FirstOrDefault(c => c.Id == id);
        }

        public bool Remove(SanPham obj)
        {
            return _iSanPhamRepository.Remove(obj);
        }

        public bool Update(SanPham obj)
        {
            return _iSanPhamRepository.Update(obj);
        }
    }
}
